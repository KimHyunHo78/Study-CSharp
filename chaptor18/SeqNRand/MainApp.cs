using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SeqNRand
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Stream outStream = new FileStream("a.dat", FileMode.Create);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x01);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x02);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x03);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.Seek(5, SeekOrigin.Current);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x04);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.Close();

            Stream inStream = new FileStream("a.dat", FileMode.Open);

            Console.WriteLine($"Read Data 1 : {inStream.ReadByte()}");
            Console.WriteLine($"Read Data 2 : {inStream.ReadByte()}");
            Console.WriteLine($"Read Data 3 : {inStream.ReadByte()}");
            inStream.Seek(5, SeekOrigin.Current);
            Console.WriteLine($"Read Data 4 : {inStream.ReadByte()}");

            inStream.Close();


        }
    }
}
