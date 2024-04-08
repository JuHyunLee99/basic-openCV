using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_struct
{
    internal class Programs
    {
        static void Main(string[] args)
        {
            // Vector 구조체
            // Vec<요소의 개수><데이터 타입>  
            // 요소의 개수: 2,3,4,6  
            // byte, ushort, short, int, float, double
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0);  // 4개의 요소를 지니는 double 백터 구조체
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);

            Console.WriteLine("\n백터 구조체");
            // 벡터 구조체의 요소 접근 방법
            Console.WriteLine(vector1.Item0);   // Item0, Item1, .. 등의 멤버 변수 사용
            Console.WriteLine(vector1[1]);  // [] 연산자 사용
            Console.WriteLine(vector1.Equals(vector2)); // 두 백터의 구조체가 일치하는지 확인



            // Point 구조체
            // Point<요소의 개수><데이터 타입> 
            // 요소의 개수: 2, 3    
            // 데이터 타입: float, double
            
            // Point 구조체와 Vector 구조체의 상호 캐스팅 가능
            Vec3d Vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt1 = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt2 = Vector;
            Console.WriteLine("\n포인트 구조체와 벡터 구조체의 상호 캐스팅");
            Console.WriteLine(Pt1);
            Console.WriteLine(Pt2);
            Console.WriteLine(Pt1.X);

            // Point 구조체와 Vector 구조체의 차이점
            // => Point 구조체로는 좌표값의 벡터 계산을 쉽게 수행할 수 있다.
            // => 벡터 간의 거리 계산, 내적, 외적, 산술 여산자(+, -, *)를 사용하여 빠른 수행 가능.
            // Pint 구조체의 벡터 연산
            Point Pt3 = new Point(1, 2);
            Point Pt4 = new Point(3, 2);

            Console.WriteLine("\n포인트 구조체의 벡터 연산");
            Console.WriteLine(Pt3.DistanceTo(Pt4)); // 거리
            Console.WriteLine(Pt3.DotProduct(Pt4)); // 내적
            Console.WriteLine(Pt3.CrossProduct(Pt4));   // 외적
            Console.WriteLine(Pt3 + Pt4);
            Console.WriteLine(Pt3 - Pt4);
            Console.WriteLine(Pt3 == Pt4);
            Console.WriteLine(Pt3 * 0.5);
            // 3차원 Point 구조체는 산술 연산자(+,-,*)와 비교 연산자(==, !=)만 지원



            // Scalar 구조체
            // [ B, G, R, A] 4개의 요소를 가짐
            // OpenCV에서 픽셀값을 전달해주는데 주로 사용
            Scalar s1 = new Scalar(255, 127);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99); // 모든 값이 99로 할당

            Console.WriteLine("\n스칼라 구조체 BGRA");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);



            // Size 구조체
            // Size, Size2f, Size2d
            // 이미지 크기
            Size size = new Size(640, 480);
            Mat img = new Mat(size, MatType.CV_8UC3);
            Mat img2 = new Mat(img.Size(), MatType.CV_8UC3);

            Console.WriteLine("\n사이즈 구조체");
            Console.WriteLine($"{size.Width}, {size.Height}");
            // Mat 클래스에서 사이즈 구조체를 메서드처럼 사용해 동일한 크기를 바로 사용할 수 있음
            Console.WriteLine(img.Size());
            Console.WriteLine($"{img.Size().Width}, {img.Size().Height}");
            Console.WriteLine($"{img.Width},{img.Height}");



            // 범위(Range) 구조체
            // 어떤 시퀀스의 범위를 지정하는데 사용
            // new Range(start, end)
            Range range = new Range(0, 100);
            Console.WriteLine("\n범위 구조체");
            Console.WriteLine($"{range.Start}, {range.End}");



            // 직사각형(Rect) 구조체
            // // 좌측 상단 좌표(포인트 구조체), 너비, 높이(사이즈 구조체)
            Rect rect1 = new Rect(new Point(0, 0), new Size(650, 1480));    
            Rect rect2 = new Rect(100, 100, 640, 1480);

            Console.WriteLine("\n직사각형 구조체");
            Console.WriteLine(rect1);
            Console.WriteLine(rect2);

            // 직사각형 구조체를 이용한 연산

            // 직사각형을 Point만큼 이동
            // Rect = Rect + Point

            // 직사각형 Size만큼 확대
            // Rect = Rect + Size

            // Size만큼 축소
            // Rect = Rect - Size

            // 두 직사각형 구조체의 영역 합집합
            // Rect = rect1 | rect2
            // 교집합
            // Rect = rect1 & rect2
            // 상등 비교
            // Rect = rect1 == rect2
            // 부등 비교
            // Rect = rect1 1= rect2



            // 회전 직사각형(RotatedRec) 구조체
            // 중심점, 크기, 각도
            // Point2f, Size2f float형식
            RotatedRect rotatedRect = new RotatedRect(new Point2f(100f, 100f), new Size2f(100, 100), 45f);  // 중심점, 크기, 각도

            Console.WriteLine("\n회전 직사각형");
            Console.WriteLine(rotatedRect.BoundingRect());  // 회전된 직사각형을 포함하는 직사각형
            Console.WriteLine(rotatedRect.Points().Length); // 회전된 직사각형의 4개의 코너 
            Console.WriteLine(rotatedRect.Points()[0]);
        }

    }
}
