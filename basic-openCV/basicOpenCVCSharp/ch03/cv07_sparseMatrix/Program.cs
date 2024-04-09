using OpenCvSharp;
using System;

// 희소 행렬
// 0 값을 지니는 요소가 전체 행렬에서 차지하는 비중이 클 때 사용하는 행렬
// 해시 테이블을 사용해 0이 아닌 요소만 저장.
// 요소가 많아지면 스스로 해시 테이블의 크기를 변경
namespace cv07_sparseMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2차원 희소 행렬
            // 지정된 type과 설정된 차원의 희소 행렬 생성
            // SparseMat( IEnumerable<int> sizes, MatType type )
            SparseMat sm1 = new SparseMat(new int[] { 1, 1 }, MatType.CV_8UC3);
            // int[] { 1, 1 } => 배열의 값이 아닌 배열의 크기로 차원 수를 할당.
            // => 2차원 내의 어느 위치에도 값을 할당할 수 있음.
            // => (99, 1000)의 위치에 (100,0,0)의 값을 할당해 사용할 수 있음.
            // => 배열의 값은 무슨 의미?
            // => Mat 클래스로 변경할때 배열의 값을 행과 열의 길이로 사용. 적절한 크기를 설정.
            sm1.Ref<Vec3b>()[99, 1000] = new Vec3b(100, 0, 0);
            Console.WriteLine(sm1.Find<Vec3b>(99, 1000).Value.Item0);



            // 희소 행렬의 요소 할당 및 접근
            // Ref(), GetIndexer() 할당
            SparseMat sm2 = new SparseMat(new int[] { 1, 1 }, MatType.CV_32F);

            SparseMat.Indexer<Vec3f> indexer = sm2.GetIndexer<Vec3f>();
            //SparseMat.Indexer<Vec3f> indexer = sm2.Ref<Vec3f>();

            //sm2.GetIndexer< Vec3f>()[0,0] = new Vec3f(4,5,6));
            indexer[0, 0] = new Vec3f(4, 5, 6);

            // 접근 .Item0
            Console.WriteLine(sm2.Get<Vec3f>(0, 0).Item0);
            Console.WriteLine(sm2.Get<Vec3f>(0, 0).Item1);
            Console.WriteLine(sm2.Get<Vec3f>(0, 0).Item2);
        }
    }
}
