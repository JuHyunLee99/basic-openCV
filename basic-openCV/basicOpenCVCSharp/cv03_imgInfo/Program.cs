using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace cv01_helloCV // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetPath = @"..\..\..\Resources\images\";
            Mat img1 = Cv2.ImRead(targetPath + "cat.bmp", ImreadModes.Grayscale);
            Mat img2 = Cv2.ImRead(targetPath + "cat.bmp", ImreadModes.Color);

            // 영상의 속성 참조
            Console.WriteLine($"type(img1): {img1.GetType()}");
            Console.WriteLine($"img1.shape: {img1.Rows}, {img1.Cols}");
            Console.WriteLine($"img2.shape: {img2.Rows}, {img2.Cols}, {img2.Channels()}");
            Console.WriteLine($"img2.dtype: {img2.Type()}");

            int h = img2.Rows, w = img2.Cols;
            Console.WriteLine($"img2 size: {w} x {h}");
            
            if (img1.Channels() == 1)
            {
                Console.WriteLine("img1 is a grayscale image");
            }
            else if (img1.Channels() == 3)
            {
                Console.WriteLine("img1 is a truecolor image");
            }

            // 영상의 픽셀 값 참조
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    img1.At<byte>(y, x) = 255; // 흰색으로 변경
                    img2.Set(y, x, new Vec3b(0, 0, 255)); // 빨간색으로 변경
                }
            }

            Cv2.ImShow("img1", img1); 
            Cv2.ImShow("img2", img2);
            Cv2.WaitKey(0);





        }
    }
}