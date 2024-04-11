using OpenCvSharp;
using OpenCvSharp.Features2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv16_draw
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 도형 그리기
            // 자세한 설명은 basicOpenCVPython에 있음.

            Mat img = new Mat(new Size(1366, 768), MatType.CV_8UC3);


            // 직선 그리기 함수
            /*
            Cv2.Line(
                Mat img,
                Point pt1,  // int pt1X, int pt1Y
                Point pt2,  // int pt2X, int pt2Y 형식도 가능
                Scalar color,
                int thickness = 1,
                LineTypes lineType = LineTypes.Link8,
                int shift = 0
            );
            */
            Cv2.Line(img, new Point(100, 100), new Point(1200, 100), new Scalar(0, 0, 255), 3, LineTypes.AntiAlias);

            // 사각형 그리기 함수
            /*
            Cv2.Rectangle(
                Mat img,
                Point pt1,  // Rect rect 형식도 가능
                Point pt2,
                Scalar color,
                int thickness = 1,
                LineTypes lineType = LineTypes.Link8,
                int shift = 0
            );
            */
            Cv2.Rectangle(img, new Point(500, 200), new Point(1000, 400), new Scalar(255, 0, 0), 5);

            // 원 그리기 함수
            /*
            Cv2.Circle(
                Mat img,
                Point center,  // Rect rect 형식도 가능
                int radius,
                Scalar color,
                int thickness = 1,
                LineTypes lineType = LineTypes.Link8,
                int shift = 0
            );
            */
            Cv2.Circle(img, new Point(300, 300), 50, new Scalar(0, 255, 0), Cv2.FILLED, LineTypes.Link4);

            // 호 그리기 함수
            /*
            Cv2.Ellipse(
                Mat img,
                Point center,
                Size axes,
                double angle,
                double startAngle,
                double endAngle,
                Scalar color,
                int thickness = 1,
                LineTypes lineType = LineTypes.Link8,
                int shift = 0
            );
            */

            Cv2.Ellipse(img, new Point(1200, 300), new Size(100, 50), 0, 90, 180, new Scalar(255, 255, 0), 2);
            
            // 내부가 채워지지 않은 다각형 그리기 함수
            /*
            Cv2.Polylines(
                Mat img,
                IEnumerable<IEnumerable<Point>> pts,
                bool true,
                Scalar color,
                int thickness = 1,
                LineTypes lineType = LineTypes.Link8,
                int shift = 0
            );
            */
            List <List<Point>> pts1 = new List<List<Point>>();  // List<>이용
            List<Point> pt1 = new List<Point>()
            {
                new Point(100, 500),
                new Point(300, 500),
                new Point(200, 600),
            };
            List<Point> pt2 = new List<Point>()
            {
                new Point(400, 500),
                new Point(500, 500),
                new Point(600, 700),
                new Point(500, 650)
            };
            pts1.Add(pt1);
            pts1.Add(pt2);
            Cv2.Polylines(img, pts1, true, new Scalar(0, 255, 255), 2);


            // 내부가 채워진 다각형 그리기 함수
            /*
            Cv2.fillPoly(
                Mat img,
                IEnumerable<IEnumerable<Point>> pts,
                Scalar color,
                LineTypes lineType = LineTypes.Link8,
                int shift = 0,
                Point? offset = null
            );
            */

            Point[] pt3 = new Point[]
            {
                new Point(700, 500),
                new Point(800, 500),
                new Point(700, 600)
            };

            Point[][] pts2 = new Point[][] { pt3 }; // 배열 이용
            Cv2.FillPoly(img, pts2, new Scalar(255, 0, 255), LineTypes.AntiAlias);

            // 문자 그리기 함수
            /*
            Cv2.PutText(
                Mat img,
                string text,
                Point org,
                HersheyFonts fontFace,
                double fontScale,
                Scalar color,
                int thickness = 1,
                LineTypes lineType = LineTypes.Link8,
                bool bottomLeftOrigin = false
            );
            */
            Cv2.PutText(img, "OpenCV", new Point(900, 600), HersheyFonts.HersheyComplex | HersheyFonts.Italic, 2.0, new Scalar(255, 255, 255), 3);

            Cv2.ImShow("img", img);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
