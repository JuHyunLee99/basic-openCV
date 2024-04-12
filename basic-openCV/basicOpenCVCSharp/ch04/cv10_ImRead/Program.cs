using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv10_ImRead
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //이미지 입력 함수
            /* 
             Cv2.ImRead(
               string fileName,
               ImreadModes flags = ImreadModes.Color   // 기본 플래그 MatType.8UC3
             );
            */

            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\OpenCV_Logo.png", ImreadModes.ReducedColor2);
            // ImreadModes.ReducedColor2 : 크기를 1/2로 줄인 후 다중 채널 색상 이미지로 반환
            Console.WriteLine(src);
        }
    }
}
