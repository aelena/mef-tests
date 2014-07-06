using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePluginDemo
{

    /// <summary>
    /// Just a quick interface. api does not matter.
    /// </summary>
    interface IDemoInterface
    {
        IEnumerable<string> Search ( string filter );

        Tuple<bool, string> WriteToDataStore ( object data );
    }
}
