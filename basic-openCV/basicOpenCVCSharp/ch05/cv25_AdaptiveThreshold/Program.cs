using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv25_AdaptiveThreshold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\swan.jpg");
            Mat gray = new Mat(src.Size(), MatType.CV_8UC1);
            Mat binary = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            // 적응형 이진화
            Cv2.AdaptiveThreshold(gray, binary, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 25,5);
            // 가우시안 가중치 적용
            // blockSize 25x25 크기 내의 영역을 분석해 적절한 임계값 설정(T(x,y)임계값 식 참고)
            // 상수 C 5
            // 상수 C를 음소로 할 경우 전체 영역이 어두어지고 큰값을 지정할 경우 전체 영역이 밝아짐

            Cv2.ImShow("binary", binary);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
