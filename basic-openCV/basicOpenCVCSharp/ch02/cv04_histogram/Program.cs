// 히스토그램
// x축: 픽셀값
// y축: 픽셀의 개수

// 히스토그램 세 가지 중요 요소
// 1. 빈도수(BINS): x축 간격
// 2. 차원수(DIMS): 이미지의 차원
// 3. 범위(RANGE): X축 범위

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace cv04_histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("image.jpg");
            Mat gray = new Mat();
            Mat hist = new Mat();
            Mat result = Mat.Ones(new Size(256, src.Height), MatType.CV_8UC1);
            Mat dst = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            // 히스토그램 계산 함수
            Cv2.CalcHist(new Mat[] { gray }, new int[] { 0 }, null, hist, 1, new int[] { 256 },
                new Rangef[] { new Rangef(0, 256) });
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                Cv2.Line(result, new Point(i, src.Height), new Point(i, src.Height -
                    hist.Get<float>(i)), Scalar.White);
            }

            Cv2.HConcat(new Mat[] { gray, result }, dst);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
