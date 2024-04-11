using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv15_concat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 이미지 연결
            // 연결할 이미지는 같은 채널과 정밀도를 가져야 함.

            // 수평 이미지 연결 함수
            // 입력된 이미지들이 동일한 행(높이)를 가져야함.
            /*
             Cv2.HConcat(
                Mat[] src,
                Mat dst
            );
            */

            // 수직 이미지 연결 함수
            // 입력된 이미지들이 동일한 열(너비)를 가져야함.
            /*
             Cv2.VConcat(
                Mat[] src,
                Mat dst
            );
            */

            Mat one = new Mat("C:\\Source\\openCV\\basic-openCV\\images\\one.jpg");
            Mat two = new Mat("C:\\Source\\openCV\\basic-openCV\\images\\two.jpg");
            Mat three = new Mat("C:\\Source\\openCV\\basic-openCV\\images\\three.jpg");
            Mat four = new Mat("C:\\Source\\openCV\\basic-openCV\\images\\four.jpg");

            Mat left = new Mat();
            Mat right = new Mat();  
            Mat dst = new Mat();

            Cv2.VConcat(new Mat[] { one, three }, left);
            Cv2.VConcat(new Mat[] { two, four }, right);
            Cv2.HConcat(new Mat[] { left, right }, dst);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
