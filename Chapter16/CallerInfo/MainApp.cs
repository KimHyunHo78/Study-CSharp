using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CallerInfo
{
    public static class Trace
    {
        public static void WriteLine(string message,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member = "")
        {
            Console.WriteLine($"{file}(line:{line}) {member}: {message}");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("취업하자!");
        }
    }
}
