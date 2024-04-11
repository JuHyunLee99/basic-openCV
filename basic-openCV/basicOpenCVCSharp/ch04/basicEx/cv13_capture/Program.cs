using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv13_capture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  동영상 입력 클래스
            // VideoCapture capture = new VideoCapture(string fileName);
            // 성공 여부를 반환하지 않음 -> 동영상 파일의 상태 값을 확인해야 함.

            VideoCapture capture = new VideoCapture("C:\\Source\\openCV\\basic-openCV\\images\\Star.mp4");
            // capture에는 입련된 동영상 파일의 정보가 담김. 프레임 값을 반환하지 않음.
            Mat frame = new Mat();

            while (true)
            {
                // 현재 프레임의 수 == 동영상의 총 프레임의 수 => 마지막 프레임까지 출력함을 의미.
                // 다시 동영상 파일을 열어 capture변수에 다시 할당시켜 계속 동영상이 나오게 함.
                if (capture.PosFrames == capture.FrameCount) capture.Open("C:\\Source\\openCV\\basic-openCV\\images\\Star.mp4");

                capture.Read(frame);    // 동영상 파일에서 프레임을 가져와 압축을 해제한 후 이미지를 frame에 저장.
                Cv2.ImShow("VideoFrame", frame);

                if (Cv2.WaitKey(33) == 'q') break;  // 33ms만큼 대기후 다음 프레임으로 넘어감.
            }

            capture.Release();  // 동영상 파일을 닫고 메모리를 해제
            Cv2.DestroyAllWindows();

        }
    }
}
