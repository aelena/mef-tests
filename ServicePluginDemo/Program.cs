using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicePluginDemo
{
    class Program
    {
        static void Main ( string [] args )
        {
            AssemblyCatalog catalog = new AssemblyCatalog ( Assembly.GetExecutingAssembly () );
            CompositionContainer container = new CompositionContainer ( catalog );

            ServiceProvider sp = new ServiceProvider ();

            container.ComposeParts ( sp );

            foreach ( var x in sp.SearchProviders )
                Console.WriteLine ( x.ToString () );

            foreach ( var x in sp.DataWriterServices )
                Console.WriteLine ( x.ToString () );

            foreach ( var s in sp.Search ( 0 ) )
                Console.WriteLine ( s );

            Console.WriteLine ("----------------------------------------------------");
    
            foreach ( var s in sp.Search ( 1 ) )
                Console.WriteLine ( s );

            Console.WriteLine ( "----------------------------------------------------" );

            var t1 = sp.Write ( 0, null );
            Console.WriteLine ( t1.Item2 );

            Console.WriteLine ( "----------------------------------------------------" );

            var t2 = sp.Write ( 0, "" );
            Console.WriteLine ( t2.Item2 );

            Console.WriteLine ( "----------------------------------------------------" );

            var t3 = sp.Write ( 1, null );
            Console.WriteLine ( t3.Item2 );

            Console.WriteLine ( "----------------------------------------------------" );

            var t4 = sp.Write ( 1, "" );
            Console.WriteLine ( t4.Item2 );

            Console.WriteLine ( "----------------------------------------------------" );

            Console.ReadLine ();
        }
    }
}
