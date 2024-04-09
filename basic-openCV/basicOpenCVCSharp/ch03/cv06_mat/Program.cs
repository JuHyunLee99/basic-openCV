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
            M.Create(488, 640, MatType.CV_8UC3); // 8bit 3채널 행렬
            M.SetTo(new Scalar(255,0,0));   // 행렬값 할당   // 첫번째 채널 255, 두번째 채널 0, 세번째 채널 0

            // 열거자를 이용한 생성자 호출
            IList<int> sizes = new List<int>() { 480, 640 };
            Mat m = new Mat(sizes, MatType.CV_8UC3);

            // Mat클래스에서 제공하는 MatExpr 정적 메서드
            // 단일 채널에 대해서만 값을 할당함.
            Mat m2 = Mat.Eye(new Size(3, 3), MatType.CV_64FC3);  // 64비트 doouble 형식 단위 행렬 생성 (첫 채널만 할당)
            
            // At() 메서드를 이용한 행렬 요소 접근
            Console.WriteLine("\nAt() 메서드를 이용한 행렬 요소 접근");
            Console.WriteLine(m2.At<double>(0, 0));
            Console.WriteLine(m2.At<Vec3d>(0, 0).Item0);
            Console.WriteLine(m2.At<Vec3d>(1, 1).Item1);
            Console.WriteLine(m2.At<Vec3d>(2, 2).Item2);
            Console.WriteLine(m2.At<Point3d>(2, 2));
            Console.WriteLine(m2.At<long>(2, 2));    // 정확하지 않은 값 출력 -> 제네릭의 타입을 선정할때  MatType의 정밀도 고려야해함. 

            // 마샬링과 포인터를 이용해 행렬 요소에 접근
            // MatExpr 클래스 - 행렬 표현식
            Mat m3 = Mat.Eye(new Size(2,2), MatType.CV_8UC2);   // 첫번째 체널에 대해서만 2x2 행렬 데이터(단위행렬)를 정상적으로 할당. 두번째 채널은 0의 값으로 할당
            Console.WriteLine("\n마샬링과 포인터를 이용해 행렬 요소에 접근");

            for (int y = 0; y < m3.Rows ; y++)
            {
                for (int x = 0; x<m3.Cols ; x++)
                {
                    // 오프셋을 계산하는 수식
                    // ofsset = Step * Row + ElemSize * Col

                    // Step() 메서드
                    // 정규화된 단계를 반환
                    // Step = Elemsize * Cols   
                    
                    // Step1()
                    // Step1 = (ElemSize/ElemSize1) * Col
                    
                    // Elemsize()
                    // 배열 요소의 크기(바이트)를 반환
                    //  MatType.CV_8UC2는 부호없는 8비트 정수형의 2채널로 구성
                    // Elemsize = 바이트 크기 * 채널 수 => 1 * 2 = 2

                    // Elemsize1()
                    // 단일 공간(하위요소)의 크기 => 1
                    int offset = (int)m3.Step() * y + m3.ElemSize() * x;    // 오프셋 지정

                    // Ptr(0) : 첫 번째 행의 포인터
                    byte i = Marshal.ReadByte(m3.Ptr(0), offset + 0);   // 지정된 오프셋 위치의 데이터 읽기
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
                    // Marshal.Read* 메서드는 반환 데이터를 Byte나 Int로 밖에 사용할 수 없어서 불현
                    // => PtrToStructure<T>()사용해서 구조체로 데이터 가져올수 있음
                    Vec3f i = Marshal.PtrToStructure<Vec3f>(m4.Ptr(0) + offset + 0);
                    Console.WriteLine($"{offset} - ({y}, {x}) : {i.Item0}, {i.Item1}, {i.Item2}");
                }
            }

        }
    }
}
