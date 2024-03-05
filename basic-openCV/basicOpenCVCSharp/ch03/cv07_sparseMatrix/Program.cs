using OpenCvSharp;
using System;


namespace cv07_sparseMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2차원 희소 행렬
            SparseMat sm1 = new SparseMat(new int[] { 1, 1 }, MatType.CV_8UC3);

            sm1.Ref<Vec3b>()[99, 1000] = new Vec3b(100, 0, 0);
            Console.WriteLine(sm1.Find<Vec3b>(99, 1000).Value.Item0);

            // 희소 행렬의 요소 할당 및 접근
            SparseMat sm2 = new SparseMat(new int[] { 1, 1 }, MatType.CV_32F);

            SparseMat.Indexer<Vec3f> indexer = sm2.GetIndexer<Vec3f>();

            indexer[0, 0] = new Vec3f(4, 5, 6);

            Console.WriteLine(sm2.Get<Vec3f>(0, 0).Item0);
            Console.WriteLine(sm2.Get<Vec3f>(0, 0).Item1);
            Console.WriteLine(sm2.Get<Vec3f>(0, 0).Item2);
        }
    }
}
