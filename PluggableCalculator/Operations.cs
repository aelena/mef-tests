using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableCalculator
{
    class Operations
    {
        [Export]
        [ExportMetadata ( "Op", "+" )]
        public int Add ( int a, int b )
        {
            return a + b;
        }

        [Export]
        [ExportMetadata ( "Op", "-" )]
        public int Substract ( int a, int b )
        {
            return a - b;
        }

        [Export]
        [ExportMetadata ( "Op", "*" )]
        public int Multiply ( int a, int b )
        {
            return a * b;
        }

        [Export]
        [ExportMetadata ( "Op", "/" )]
        public int Divide ( int a, int b )
        {
            return a / b;
        }

        /// <summary>
        /// even your own custom operators
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [Export]
        [ExportMetadata ( "Op", "_" )]
        public int Smaller ( int a, int b )
        {
            return ( a > b ) ? b : a;
        }

        [Export]
        [ExportMetadata ( "Op", "¬" )]
        public int Larger ( int a, int b )
        {
            return ( a > b ) ? a : b;
        }
    }
}
