using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv08_ROI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mat 클래스를 이용한 관심 영역 설정
            Mat m = new Mat(1280, 1920, MatType.CV_8UC3);

            // 블록 단위 접근 메서드
            Mat roi1 = new Mat(m, new Rect(300, 300, 100, 100));    // 행렬 m의 직사각형 구조체에 해당하는 배열 반환
            // 데이터를 복사하는 생성자
            Mat roi2 = m[0, 100, 0, 100];   

            Mat roi3 = m.SubMat(100, 300, 200, 300);

            Console.WriteLine(m);
            Console.WriteLine(roi1);
            Console.WriteLine(roi2);
            Console.WriteLine(roi3);

        }
    }
}
