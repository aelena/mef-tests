using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluggableCalculator
{
    class Program
    {
        static void Main ( string [] args )
        {
            var catalog = new AssemblyCatalog ( Assembly.GetExecutingAssembly () );
            CompositionContainer container = new CompositionContainer ( catalog );

            var calculator = container.GetExportedValue<Calculator> ();

            // set up a loop of calculations
            while(true)
            {
                Console.WriteLine ("Enter your calculation here: ");
                string input = Console.ReadLine ();

                Console.WriteLine ( "Result: {0}", calculator.Calculate ( input ) );
            }
        }
    }
}
