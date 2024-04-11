using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv12_MouseCallback
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 마우스 콜백 설정 함수
            /*
            Cv2.SetMouseCallback(
                string windowName,
                MouseCallback onMouse,
                IntPtr userdata = default
            );
            */

            // 마우스 콜백 델리게이트
            /*
            MouseCallback(
                MouseEventTypes @event,
                int x,
                int y,
                MouseEventFlags flags,
                IntPtr userdata
            );
            */

            Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3, new Scalar(255, 255, 255));

            Cv2.ImShow("draw", src);
            MouseCallback cvMouseCallback = new MouseCallback(Event);
            Cv2.SetMouseCallback("draw", cvMouseCallback, src.CvPtr);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        private static void Event(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userdata)
        {
            Mat data = new Mat(userdata);

            if (flags == MouseEventFlags.LButton)   //  마우스 왼쪽 버튼을 누른 상태
            {
                Cv2.Circle(data, new Point(x, y), 10, new Scalar(0, 0, 255), -1);
                Cv2.ImShow("draw", data);
            }
        }
    }
}
