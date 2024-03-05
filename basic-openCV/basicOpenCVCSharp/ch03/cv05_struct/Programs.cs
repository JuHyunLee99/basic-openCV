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
            // 백터 구조체
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0);
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);

            Console.WriteLine("\n백터 구조체");
            Console.WriteLine(vector1.Item0);
            Console.WriteLine(vector1[1]);
            Console.WriteLine(vector1.Equals(vector2));

            // 포인트 구조체와 벡터 구조체의 상호 캐스팅
            Vec3d Vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt1 = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt2 = Vector;

            Console.WriteLine("\n포인트 구조체와 벡터 구조체의 상호 캐스팅");
            Console.WriteLine(Pt1);
            Console.WriteLine(Pt2);
            Console.WriteLine(Pt1.X);

            // 포인트 구조체의 벡터 연산
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
            // 3차원 포인트 구조체는 산술 연산자(+,-,*)와 비교 연산자(==, !=)만 지원

            // 스칼라 구조체
            Scalar s1 = new Scalar(255, 127);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99);

            Console.WriteLine("\n스칼라 구조체 BGRA");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            // 사이즈 구조체
            Size size = new Size(640, 480);
            Mat img = new Mat(size, MatType.CV_8UC3);
            Mat img2 = new Mat(img.Size(), MatType.CV_8UC3);

            Console.WriteLine("\n사이즈 구조체");
            Console.WriteLine($"{size.Width}, {size.Height}");
            Console.WriteLine(img.Size());
            Console.WriteLine($"{img.Size().Width}, {img.Size().Height}");
            Console.WriteLine($"{img.Width},{img.Height}");

            // 범위 구조체
            Range range = new Range(0, 100);
            Console.WriteLine("\n범위 구조체");
            Console.WriteLine($"{range.Start}, {range.End}");

            // 직사각형 구조체
            Rect rect1 = new Rect(new Point(0, 0), new Size(650, 1480));    // 좌측 상단 좌표 기준
            Rect rect2 = new Rect(100, 100, 640, 1480);

            Console.WriteLine("\n직사각형 구조체");
            Console.WriteLine(rect1);
            Console.WriteLine(rect2);

            // 회전 직사각형
            RotatedRect rotatedRect = new RotatedRect(new Point2f(100f, 100f), new Size2f(100, 100), 45f);  // 중심점, 크기, 각도

            Console.WriteLine("\n회전 직사각형");
            Console.WriteLine(rotatedRect.BoundingRect());
            Console.WriteLine(rotatedRect.Points().Length);
            Console.WriteLine(rotatedRect.Points()[0]);
        }

    }
}
