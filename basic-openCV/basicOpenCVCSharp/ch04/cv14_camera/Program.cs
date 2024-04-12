using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv14_camera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 카메라 출력
            // VideoCapture capture = new VideoCapture(int index);
            
            VideoCapture capture = new VideoCapture(0);
            Mat frame = new Mat();
            capture.Set(VideoCaptureProperties.FrameWidth, 640);
            capture.Set(VideoCaptureProperties.FrameHeight, 480);


            while(true)
            {
                if (capture.IsOpened() == true)
                {
                    capture.Read(frame);
                    Cv2.ImShow("VideoFrame", frame);
                    if (Cv2.WaitKey(33) == 'q') break;
                }
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
