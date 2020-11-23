using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace WithPython
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("n", "박상현");
            scope.SetVariable("p", "010-1234-5667");

            ScriptSource source = engine.CreateScriptSourceFromString(
                @"
class NameCard :
    name = ''
    phone = ''

    def __init__(self, name, phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print self.name + ', ' + self.phone

NameCard(n,p)
");
            //def __init__(self, name, phone) : 에서 _ 이거 두개임.

            dynamic result = source.Execute(scope);

            Console.WriteLine("메소드 실행");
            result.printNameCard();

            Console.WriteLine("직접 호출해서 출력");
            Console.WriteLine("{0}, {1}", result.name, result.phone);


        }
    }
}
