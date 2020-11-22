using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace EmitTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            AssemblyBuilder newAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName("CalculatorAssembly"),
                AssemblyBuilderAccess.Run);

            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");
            TypeBuilder newType = newModule.DefineType("Sum1To100");

            MethodBuilder newMethod = newType.DefineMethod(
                "Calculate", MethodAttributes.Public, typeof(int), new Type[0]);

            ILGenerator generator = newMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldc_I4, 1);

            for( int i = 2; i <= 100; i++ )
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }

            generator.Emit(OpCodes.Ret);
            newType.CreateType();

            //위에는 동적으로 클래스를 선언.

            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            var val = Calculate.Invoke(sum1To100, null);
            Console.WriteLine(Calculate.Invoke(sum1To100, null));
        }
    }
}
