using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv30_GetRotationMatrix2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\glass.jpg");
            Mat dst = new Mat();

            Cv2.Flip(src, dst, FlipMode.Y);
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(src.Width / 2, src.Height / 2), 90.0, 1.0);    // 센터: 이미지 중심, 비율 1.0, 회전 90도
            Cv2.WarpAffine(dst, dst, matrix, new Size(src.Width, src.Height));  // 아핀 전환 함수

            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
    }
}
