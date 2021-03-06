﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIstoryAttrivute
{
    [System.AttributeUsage(System.AttributeTargets.Class,AllowMultiple =true)]
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            this.version = 1.0;
            this.changes = "First release";
        }

        public string GetProgrammer()
        {
            return programmer;
        }
    }

    [History("Sean",version = 0.1, changes = "2020-11-23 Created class stub")]
    [History("KHH", version = 0.2, changes = "2020-11-23 Added Func() Method")]
    [History("KHH2", version = 0.3, changes = "2020-11-23 Modify Func() Method")]
    class MyClass
    {
        public void Func()
        {
            Console.WriteLine("Func()");
            Console.WriteLine("modify in Desktop ");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            Console.WriteLine("MyClass change history...");

            foreach(Attribute a in attributes )
            {
                History h = a as History;
                if( h != null)
                {
                    Console.WriteLine("Ver:{0}, Programmer:{1}, Changes:{2}",
                        h.version, h.GetProgrammer(), h.changes);
                }
            }
        }
    }
}
