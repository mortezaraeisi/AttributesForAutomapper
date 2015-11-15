using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesForAutomapper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreMapAttribute : Attribute
    {
    };
}
