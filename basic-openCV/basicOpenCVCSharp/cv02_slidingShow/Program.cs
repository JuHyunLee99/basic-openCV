using OpenCvSharp;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace cv02_slidingShow // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetPath = @"..\..\..\Resources\images";
            // .jpg 파일들
            string[] img_files = Directory.GetFiles(targetPath, "*.jpg");
            // cv2.WINDOW_NORMAL 속성의 창을 만든 후, 전체화면 속성으로 변경
            Cv2.NamedWindow("image", WindowFlags.Normal);
            Cv2.SetWindowProperty("image", WindowPropertyFlags.Fullscreen, 1);

            int cnt = img_files.Length;
            int idx = 0;
            Mat img;
            while (true)
            {
                img = Cv2.ImRead(img_files[idx]);

                if (img == null )
                {
                    Console.WriteLine("Image load failed");
                    break;
                }

                Cv2.ImShow("image", img);
                if (Cv2.WaitKey(1000) >= 0) break;

                idx += 1;
                if (idx >= cnt)
                    idx = 0;
            }
        }
    }
}
