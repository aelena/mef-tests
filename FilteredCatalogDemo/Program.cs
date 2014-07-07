using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilteredCatalogDemo
{
    class Program
    {
        static void Main ( string [] args )
        {
            var catalog = new AssemblyCatalog ( Assembly.GetExecutingAssembly () );
            var filteredCatalog = new FilteredCatalog ( catalog, CheckPartFitsCriteria ) { Criteria = "IsProduction" };
            var container = new CompositionContainer ( filteredCatalog );

            var filteredCatalog2 = new FilteredCatalog2 ( catalog, CheckPartFitsCriteria2 ) { Criteria = "Country", Value = "UK" };
            var container2 = new CompositionContainer ( filteredCatalog2 );

            Console.ReadKey ();
        }

        private static bool CheckPartFitsCriteria ( ComposablePartDefinition partsDefinition, string criteria )
        {
            var _x = ( from p in partsDefinition.ExportDefinitions
                       where p.Metadata.ContainsKey ( criteria )
                       select p ).Any ( p => bool.Parse ( p.Metadata [ criteria ].ToString () ) );
            return _x;
        }

        private static bool CheckPartFitsCriteria2 ( ComposablePartDefinition partsDefinition,
            string metadataKey,
            string metadataValue )
        {
            var _x = partsDefinition.ExportDefinitions.Any ( 
                        p => p.Metadata.Contains ( 
                               new KeyValuePair<string, object> ( metadataKey, metadataValue ) ) );
            return _x;
        }
    }


    [Export]
    [ExportMetadata ( "Country", "ES" )]
    [ExportMetadata ( "IsProduction", true )]
    class ClassA { }

    [Export]
    [ExportMetadata ( "IsProduction", false )]
    [ExportMetadata ( "Country", "IT" )]
    class ClassB { }

    [Export]
    [ExportMetadata ( "IsProduction", true )]
    [ExportMetadata ( "Country", "UK" )]
    class ClassC { }

}
