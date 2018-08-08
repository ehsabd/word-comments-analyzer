using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Security.Cryptography;

namespace WordCommentsAnalyzerBenchmark
{
    public class MyBenchmark
    {
        private const int N = 100;
        private WordCommentsAnalyzer.Main main;
        public MyBenchmark()
        {
            main = new WordCommentsAnalyzer.Main();
        }
        [Benchmark]
        public void BenchmarkAnalyze() => main.AnalyzeFiles(@"D:\My Documents\Projects\Bots_Scrapers\MoH_CC_JournalsScraper\ConvertCsvToWord\bin\Debug\Word");
    }
    public static class MyListExtensions
    {
        public static double Mean(this List<double> values)
        {
            return values.Count == 0 ? 0 : values.Mean(0, values.Count);
        }

        public static double Mean(this List<double> values, int start, int end)
        {
            double s = 0;

            for (int i = start; i < end; i++)
            {
                s += values[i];
            }

            return s / (end - start);
        }

        public static double Variance(this List<double> values)
        {
            return values.Variance(values.Mean(), 0, values.Count);
        }

        public static double Variance(this List<double> values, double mean)
        {
            return values.Variance(mean, 0, values.Count);
        }

        public static double Variance(this List<double> values, double mean, int start, int end)
        {
            double variance = 0;

            for (int i = start; i < end; i++)
            {
                variance += Math.Pow((values[i] - mean), 2);
            }

            int n = end - start;
            if (start > 0) n -= 1;

            return variance / (n);
        }

        public static double StandardDeviation(this List<double> values)
        {
            return values.Count == 0 ? 0 : values.StandardDeviation(0, values.Count);
        }

        public static double StandardDeviation(this List<double> values, int start, int end)
        {
            double mean = values.Mean(start, end);
            double variance = values.Variance(mean, start, end);

            return Math.Sqrt(variance);
        }
    }

    class BenchmarkProgram
    {
       
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var b = new MyBenchmark();
            var times = new List<double>();
            long t0 = 0;
            for (var i = 0; i < 100; i++)
            {
                b.BenchmarkAnalyze();
                var time = Convert.ToDouble(sw.ElapsedMilliseconds - t0);
                Console.WriteLine(time.ToString());
                times.Add(time);
                t0 = sw.ElapsedMilliseconds;
                
            }

            Console.WriteLine(times.Mean());
            Console.WriteLine(times.StandardDeviation());
        }


        
        
    }
}
