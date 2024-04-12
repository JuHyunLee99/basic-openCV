using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv19_saveImage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(new Size(640, 480), MatType.CV_8UC3);
            bool save;

            // 이미지 저장
            /*
            Cv2.ImWrite(
                string fileName,
                Mat img,
                params ImageEncodingParam[] prmss
            );
            */

            ImageEncodingParam[] prms = new ImageEncodingParam[]
            {
                new ImageEncodingParam(ImwriteFlags.JpegQuality, 100),
                new ImageEncodingParam(ImwriteFlags.JpegProgressive, 1)
            };

            save = Cv2.ImWrite("CV.jpeg", img, prms);
            Console.WriteLine(save);
        }
    }
}
