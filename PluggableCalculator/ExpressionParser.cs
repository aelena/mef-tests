using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PluggableCalculator
{
    class ExpressionParser
    {
        [Export ( "ExpressionParser" )]
        public CalculationModel ParseExpression ( string expression )
        {
            var regex = new Regex ( @"(\d+)(.)(\d+)" );
            var match = regex.Match ( expression );

            var calcModel = new CalculationModel
            {
                Input1 = int.Parse(match.Groups[1].Value),
                Input2 = int.Parse(match.Groups[3].Value),
                Op = match.Groups[2].Value
            };

            return calcModel;
        }
    }
}
