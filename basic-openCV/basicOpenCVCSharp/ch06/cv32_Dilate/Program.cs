using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv32_Dilate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\dandelion.jpg", ImreadModes.Grayscale);
            Mat dst = new Mat();

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Cross, new Size(7, 7));  // 십자가 형태, 7x7 크기
            // 고정점 중심, 팽창 3회, 데투리 외삽법 반사, 테두리 색상 검은색
            Cv2.Dilate(src, dst, kernel, new Point(-1, -1), 3, BorderTypes.Reflect101, new Scalar(0)); 

            //Cv2.NamedWindow("dst", WindowFlags.Normal);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
