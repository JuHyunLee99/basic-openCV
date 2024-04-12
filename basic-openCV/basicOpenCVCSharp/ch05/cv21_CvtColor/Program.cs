using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv21_CvtColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\crow.jpg");
            Mat dst = new Mat(src.Size(), MatType.CV_8UC1);

            // 색상 공간 변환 함수
            /*
            Cv2.CvtColor(
                Mat src,
                Mat dst,
                ColorConversionCodes code,
                int dstCn = 0
            );
            */

            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
    }
}
