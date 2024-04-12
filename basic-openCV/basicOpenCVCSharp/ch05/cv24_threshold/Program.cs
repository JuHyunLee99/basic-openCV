using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv24_threshold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\swan.jpg");
            Mat gray = new Mat(src.Size(), MatType.CV_8UC1);
            Mat binary = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            // 이진화 함수
            /*
            Cv2.Threshold(
                Mat src,
                Mat dst,
                double thresh,      // 임계값
                double maxval,      // 최대값
                ThresholdTypes type // 임계형식 OR연산 가능
            );
            */

            Cv2.Threshold(gray, binary, 127, 255, ThresholdTypes.Otsu);
            // 오츠(Otsu)의 알고리즘 적용
            // 단일 채널 이미지에서만 연산가능
            // 여기서 127(임계값), 255(최댓값)는 영향 없음. 오츠(Otsu)의 알고리즘으로 이진화 이루어짐.
            // 임계형식에 OR로 추가적인 이진화 알고리즘을 적용할때는 임계값과 최댓값이 적용됨

            Cv2.ImShow("binary", binary);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
    }
}
