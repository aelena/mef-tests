using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableCalculator
{

    [Export]
    class Calculator
    {
        [Import ( "ExpressionParser" )]
        private Func<string, CalculationModel> Parser;

        [ImportMany]
        private IEnumerable<Lazy<Func<int,int,int>, Dictionary<string,object>>> availableOperations;

        /// <summary>
        /// this will parse the operation as a string (like a command)
        /// perform the calculation and return the result
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public int Calculate(string operation)
        {
            var calculation = this.Parser ( operation );
            var operationToRun = availableOperations.First ( x => x.Metadata [ "Op" ].ToString ().Equals ( calculation.Op ) );
            var result = operationToRun.Value ( calculation.Input1, calculation.Input2 );
            return result;
        }
    }
}
