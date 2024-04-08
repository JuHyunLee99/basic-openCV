using OpenCvSharp;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06_mat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mat 클래스
            Mat M = new Mat();
            M.Create(MatType.CV_8UC3, new int[] {488, 640});
            M.Create(new Size(488, 640), MatType.CV_8UC3);
            M.Create(488, 640, MatType.CV_8UC3);
            M.SetTo(new Scalar(255,0,0));   // 행렬값 할당   // 첫번째 채널 255, 두번째 채널 0, 세번째 채널 0

            // 열거자를 이용한 생성자 호출
            IList<int> sizes = new List<int>() { 480, 640 };
            Mat m = new Mat(sizes, MatType.CV_8UC3);

            // At() 메서드를 이용한 행렬 요소 접근
            Mat m2 = Mat.Eye(new Size(3, 3), MatType.CV_64FC3);  // 64비트 doouble 형식
            Console.WriteLine("\nAt() 메서드를 이용한 행렬 요소 접근");
            Console.WriteLine(m2.At<double>(0, 0));
            Console.WriteLine(m2.At<Vec3d>(0, 0).Item0);
            Console.WriteLine(m2.At<Vec3d>(1, 1).Item1);
            Console.WriteLine(m2.At<Vec3d>(2, 2).Item2);
            Console.WriteLine(m2.At<Point3d>(2, 2));
            Console.WriteLine(m2.At<long>(2, 2));    // 정확하지 않은 값 출력 -> MatTyle의 정밀도 고려야해함. 

            // 마샬링과 포인터를 이용해 행렬 요소에 접근
            // MatExpr 클래스 - 행렬 표현식
            Mat m3 = Mat.Eye(new Size(2,2), MatType.CV_8UC2);   // 첫번째 체널에 대해서만 2x2 행렬 데이터(단위행렬)를 정상적으로 할당. 두번째 채널은 0의 값으로 할당
            Console.WriteLine("\n마샬링과 포인터를 이용해 행렬 요소에 접근");

            for (int y = 0; y < m3.Rows ; y++)
            {
                for (int x = 0; x<m3.Cols ; x++)
                {
                    int offset = (int)m3.Step() * y + m3.ElemSize() * x;    // 오프셋 지정
                    byte i = Marshal.ReadByte(m3.Ptr(0), offset + 0);
                    //byte j = Marshal.ReadByte(m3.Ptr(0), offset + 1);
                    //byte k = Marshal.ReadByte(m3.Ptr(0), offset + 2);
                    Console.WriteLine($"{offset} - ({y}, {x}) : {i}");
                }
            }


            // 형식 매개 변수와 포인터를 이용해 행렬 요소에 접근
            Mat m4 = Mat.Eye(new Size(2, 2), MatType.CV_32FC3);
            Console.WriteLine("\n형식 매개 변수와 포인터를 이용해 행렬 요소에 접근");

            for (int y = 0; y <m4.Rows; y++)
            {
                for(int x = 0; x< m4.Cols ; x++)
                {
                    int offset = (int)m4.Step()*y + m4.ElemSize() * x;   // offset 지정
                    Vec3f i = Marshal.PtrToStructure<Vec3f>(m4.Ptr(0) + offset + 0);
                    Console.WriteLine($"{offset} - ({y}, {x}) : {i.Item0}, {i.Item1}, {i.Item2}");
                }
            }

        }
    }
}
