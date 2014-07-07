using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimplestConsoleMEFDemo.Types;

namespace SimplestConsoleMEFDemo
{
    class Program
    {
        static void Main ( string [] args )
        {

            AssemblyCatalog catalog = new AssemblyCatalog ( Assembly.GetExecutingAssembly () );
            CompositionContainer container = new CompositionContainer ( catalog );
            var car = new Car ();
            container.ComposeParts ( car );
            car.Drive ();
            Console.ReadLine ();
        }
    }
}
