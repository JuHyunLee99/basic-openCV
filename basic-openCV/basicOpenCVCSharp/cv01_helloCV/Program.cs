using OpenCvSharp ;


namespace cv01_helloCV // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello OpenCV {Cv2.GetVersionString()}");

            // cat.bmp파일을 불러와 img 변수에 저장
            Mat img = Cv2.ImRead(@"..\..\..\..\Resources\cat.bmp");

            // "image"라는 이름의 새 창을 만들고,
            // 이 창에 img영상을 출력하고,
            // 키보드 입력이 있을 때까지 대기.
            Cv2.NamedWindow("image");
            Cv2.ImShow("image", img);
            Cv2.WaitKey(0);

            // 생성된 모든 창 닫음
            Cv2.DestroyAllWindows();    
        }
    }
}
