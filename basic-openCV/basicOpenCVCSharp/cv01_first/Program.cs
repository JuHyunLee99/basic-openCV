using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace cv01_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // openCV버전 확인
            Console.WriteLine(Cv2.GetVersionString());

        }
    }
}
