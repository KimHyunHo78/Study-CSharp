using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create));
            sw.WriteLine(int.MaxValue);
            sw.WriteLine("Good moring");
            sw.WriteLine(uint.MaxValue);
            sw.WriteLine("안녕하세요!");
            sw.WriteLine(double.MaxValue);

            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("a.txt", FileMode.Open));

            Console.WriteLine($"File Size : {sr.BaseStream.Length} Bytes");

            while( sr.EndOfStream == false)
            {
                Console.WriteLine(sr.ReadLine());
            }

            sr.Close();

        }
    }
}
