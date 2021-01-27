using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace proyecto_lyaii
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser(printSource: true)]
    [RyuJitX64Job]
    public class OperacionCodigo
    {
        // Es opcional el uso de campos globales
        int[] campo = Enumerable.Range(0, 100).ToArray();

        // Escribir código ...

        [Benchmark]
        public int SumaLocal()
        {
            var local = campo;

            int sum = 0;
            for (int i = 0; i < local.Length; i++)
                sum += local[i];

            return sum;
        }

        [Benchmark]
        public int SumaCampo()
        {
            int sum = 0;
            for (int i = 0; i < campo.Length; i++)
                sum += campo[i];

            return sum;
        }

        // Metodos rápidos
        [Benchmark]
        public byte[] ArregloVacio() => Array.Empty<byte>();

        [Benchmark]
        public byte[] OchoBytes() => new byte[8];

        [Benchmark]
        public byte[] UnLinq()
        {
            return Enumerable
                .Range(0, 100)
                .Where(i => i % 2 == 0)
                .Select(i => (byte)i)
                .ToArray();
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
