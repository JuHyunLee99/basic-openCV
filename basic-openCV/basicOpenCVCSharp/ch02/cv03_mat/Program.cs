using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
namespace cv03_mat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 크기, 정밀도, 채널 표현
            int width = 640;
            int height = 480;

            int rows = 480;
            int cols = 640;

            Mat color = new Mat(new Size(width, height), MatType.CV_8UC3);
            Mat gray = new Mat(rows, cols, MatType.CV_8UC1);

            // 관심 영역 ROI(Region Of Interest)
            // 이미지상에서 관심 있는 영역

            // 관심 채널 COI(Channel Of Inerest)
            // 색상 요소가 중요하지 않은 알고리즘의 경우
            // 각 채널에 대한 연산이 그레이스케일보다 더 높은 정확도를 보일 수 있음.
            // 그레이스케일의 경우 Y = 0.299 x R + 0.587 x G + 0.114 x B 공식으로 얻음.
            // 이때 데이터의 변형이 발생.
        }
    }
}
