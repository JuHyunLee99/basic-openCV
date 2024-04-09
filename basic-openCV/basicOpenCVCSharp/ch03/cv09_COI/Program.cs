using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv09_COI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat m = new Mat(1280, 1920, MatType.CV_8UC3);

            Mat coi = m.ExtractChannel(0);
            //  MatType.CV_8UC1로 변경됨, 하위행렬이 아님
            Console.WriteLine(coi);
        }
    }
}
