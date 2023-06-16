using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays
{
    internal interface IMenu
    {
        static abstract void Start();

        static abstract void DrawRule(string ruleName);
    }
}
