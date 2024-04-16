using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv27_Blur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 흐림 효과
           

            Mat src = Cv2.ImRead("C:\\Source\\openCV\\basic-openCV\\images\\crescent.jpg");
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);
            // 가우시안 흐림 효과
            Cv2.GaussianBlur(src, dst, new Size(9, 9), 3, 3, BorderTypes.Isolated);
            // ksize: 9x9
            // x방향 가우스 커널 표준 편차, y방향 가우스 커널 표준 편차 : 3, 3
            // 테두리 픽셀들이 모두 검은 색의 값을 갖고 이ㅣㅆ는 이미지 이므로 테두리 외삽을 고려하지 않도록 BorderTypes.Isolated 설정
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
    }
}
