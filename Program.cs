using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace proyecto_lyaii
{
    [HtmlExporter]
    [DisassemblyDiagnoser(printSource: true)]
    [RyuJitX64Job]
    public class OperacionCodigo
    {
        // Es opcional el uso de campos globales
        int[] field = Enumerable.Range(0, 100).ToArray();

        [Benchmark]
        public int main()
        {
            // Escribe código aqui...
            var local = field;

            int sum = 0;
            for (int i = 0; i < local.Length; i++)
                sum += local[i];

            // No te olvides del return
            return sum;
        }
    }

    public class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var summary = BenchmarkRunner.Run<OperacionCodigo>();
        }
    }
}
