using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv26_solve
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 연산

            // 덧셈함수
            // 뺄셈 함수
            // 곱셈 함수
            // 나눗셈 함수
            // 최댓값 함수
            // 최소값 함수
            // 최소/최대 위치 반환 함수
            // 절댓값 함수
            // 절댓값 차이 함수
            // 비교함수
            Mat src1 = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\gerbera.jpg");
            Mat dst = new Mat(src1.Size(), MatType.CV_8UC3);

            Cv2.Compare(src1, new Scalar(200, 127, 100), dst, CmpType.GT);
            //  CmpType.GT : src1이 src2보다 큼

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
            // 선형 방정식 시스템의 해 찾기 함수
            // AND 연산 함수
            // OR 연산 함수
            // XOR 연산 함수
            // NOT 연산 함수


        }
    }
}
