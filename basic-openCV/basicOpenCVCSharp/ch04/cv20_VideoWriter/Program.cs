using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace cv20_VideoWriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VideoCapture capture = new VideoCapture("C:\\Source\\openCV\\basic-openCV\\images\\Star.mp4");
            Mat frame = new Mat(new Size(capture.FrameWidth, capture.FrameWidth), MatType.CV_8UC3);
            VideoWriter videoWriter = new VideoWriter();
            bool isWrite = false;

            while(true) 
            {
                if (capture.PosFrames == capture.FrameCount) capture.Open("C:\\Source\\openCV\\basic-openCV\\images\\Star.mp4");

                capture.Read(frame);
                Cv2.ImShow("VideoFrame", frame);

                int key = Cv2.WaitKey(33);
                if (key == 4)
                {
                    videoWriter.Open("Video.avi", FourCC.XVID, 30, frame.Size(), true);
                    isWrite = true;
                }
                else if (key == 24)
                {
                    videoWriter.Release();
                    isWrite = false;
                }
                else if (key == 'q') break;

                if (isWrite == true) videoWriter.Write(frame);
            }

            videoWriter.Release();
            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
