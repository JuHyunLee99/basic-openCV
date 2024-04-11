using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11_ImShow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 출력
            /* 
             Cv2.ImShow(
                string winname.
                Mat mat
            );
            */

            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\OpenCV_Logo.png", ImreadModes.ReducedColor2);

            Cv2.NamedWindow("src", WindowFlags.GuiExpanded);    // 윈도우 생성
            Cv2.SetWindowProperty("src", WindowPropertyFlags.Fullscreen, 0);  // 해당 이름의 윈도우 속성 설정 
            Cv2.ImShow("src", src); // 윈도우에 이미지 표시  // 해당 이름의 윈도우가 없을 경우 새로운 윈도우를 생성해서 이미지 출력
            Cv2.WaitKey(0); // 지정된 시간동안 키 입력 기다림.   // 단위 ms    // 0 or 음수일 경우 키 입력이 있을때까지 기다림
            Cv2.DestroyWindow("src");   // 만들어진 윈도우를 닫고 메모리 사용 해제
        }
    }
}
