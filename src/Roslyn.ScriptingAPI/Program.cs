using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;

namespace Roslyn.ScriptingAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your csharp script : ");
            string code = Console.ReadLine().ToString();

            var globals = new Globals { X = 1, Y = 2 };
            var script = CSharpScript.Create<int>(code, globalsType: typeof(Globals));
            script.Compile();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine((script.RunAsync(new Globals { X = i, Y = i })).Result.ReturnValue);
            }
            Console.ReadKey();
        }
    }

    public class Globals
    {
        public int X;
        public int Y;
    }
}
