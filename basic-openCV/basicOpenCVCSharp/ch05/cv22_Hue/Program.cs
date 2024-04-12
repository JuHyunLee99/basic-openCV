using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv22_Hue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\tomato.jpg");
            Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);

            // 채널 분리 함수
            /*
            Mat[] mv = Cv2.Split(
                Mat src
            );
            */
            // 채널 병합 함수
            /*
            Cv2.Merge(
                Mat[] mv,
                Mat dst
            );
            */
            Mat[] HSV = Cv2.Split(hsv);
            Mat H_orange = new Mat(src.Size(), MatType.CV_8UC1);
           
            // 배열 요소의 범위 설정 함수
            // 검출하는 값과 일치하는 범위는 255할당, 아닌 건 0할당
            /*
            Cv2.InRange(
                Mat src,
                Scalar lowerb,  // 최소 범위
                Scalar upperb,  // 최대 범위
                Mat dst
            );
            */
            Cv2.InRange(HSV[0], new Scalar(8), new Scalar(20), H_orange);

            Cv2.BitwiseAnd(hsv, hsv, dst, H_orange);    // 마스크 씌움
            // Cv2.ImShow()는 BGR 색상 공간만 정상적으로 출력하므로 BGR로 다 바꿔줌
            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);

            Cv2.ImShow("source", src);  
            Cv2.ImShow("Orange", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
