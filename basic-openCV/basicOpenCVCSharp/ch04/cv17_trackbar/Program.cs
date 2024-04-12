using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv17_trackbar
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
            Cv2.NamedWindow("Palette");

            // 트랙 바 생성 함수
            /*
            Cv2.CreateTrackbar(
                string trackbarName,
                string winName,
                ref int value,  // 트랙 바의 초기 슬라이더 위치, 위치가 변경될 때마다 갱신
                int count,      // 트랙 바의 최ㅐ 위치
                TrackbarCallbackNative onChange = null, // 콜백함수
                InPtr userDaata = default
                );
            */
            Cv2.CreateTrackbar("Color", "Palette", ref value, 255);

            while (true)
            {
                int pixel = Cv2.GetTrackbarPos("Color", "Palette");
                Mat src= new Mat(new Size(500, 500), MatType.CV_8UC3, new Scalar(pixel, value, value));

                Cv2.ImShow("Palette", src);
                if (Cv2.WaitKey(50) == 'q') break;
            }

            Cv2.DestroyAllWindows();
        }
    }
}
