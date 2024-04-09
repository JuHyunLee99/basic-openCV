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
            
            // 행 0~99, 열 0~99에 해당하는 배열 반환
            Mat roi2 = m[0, 100, 0, 100];   

            Mat roi3 = m.SubMat(100, 300, 200, 300);

            // 헤더
            // IsContinuous : 행렬의 요소가 각 행의 끝에 간격 없이 연속적으로 저장되는 경우 True
            // -> 하위 행렬은 원본 행렬에서 분리돼 생성되어 연속적이지 않아 False
            // => 하위 행렬로 생성됐다고 IsContinuous가 항상 False는 아님.
            // 1x1행렬, n*1의 단일 행을 갖는 행렬일 경우 행렬은 항상 연속성을 갖게 되어 True
            // IsSubmatrix : 관심 영역으로 지정된 행렬이거나 하위 행렬이 경우 True
            Console.WriteLine(m);
            Console.WriteLine(roi1);
            Console.WriteLine(roi2);
            Console.WriteLine(roi3);

        }
    }
}
