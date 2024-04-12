using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cv23_colorDetection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\tomato.jpg");
            Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
            Mat lower_red = new Mat(src.Size(), MatType.CV_8UC3);
            Mat upper_red = new Mat(src.Size(), MatType.CV_8UC3);
            Mat added_red = new Mat(src.Size(), MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);

            Cv2.InRange(hsv, new Scalar(0, 100, 100), new Scalar(5, 255, 255), lower_red);
            Cv2.InRange(hsv, new Scalar(170, 100, 100), new Scalar(179, 255, 255), upper_red);

            // 배열 병합 함수
            /*
            Cv2.AddWeighted(
                Mat src1,
                double alpha,
                Mat src2,
                double beta,
                double gamma,
                Mat dst,
                int dtype = -1
            );
            */
            // 배열 병합 함수 수식
            // dst = src1 x alpha + src2 x beta + gamma
            Cv2.AddWeighted(lower_red, 1.0, upper_red, 1.0, 0.0, added_red);

            Cv2.BitwiseAnd(hsv, hsv, dst, added_red);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);

            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
