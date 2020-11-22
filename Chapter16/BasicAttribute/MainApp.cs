using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAttribute
{
    class MyClass
    {
        [Obsolete("OldMethod는 폐기되었습니다. NewMethod()를 사용하세요.")]
        public void OldMethod()
        {
            Console.WriteLine("I'm Old");
        }

        public void NewMethod()
        {
            Console.WriteLine("I'm New");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.OldMethod();
            myClass.NewMethod();
        }
    }
}
