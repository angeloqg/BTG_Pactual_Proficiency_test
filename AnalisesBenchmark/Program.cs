using AnalyzeLessBricks;
using BenchmarkDotNet.Running;

namespace AnalisesBenchmark
{
    public static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<AnalisesBrickWall>();
        }
    }
}
