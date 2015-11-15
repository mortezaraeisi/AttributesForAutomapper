using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AttributesForAutomapper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UseValueResolverAttribute : Attribute
    {
        public IValueResolver ValueResolver { get; private set; }

        public UseValueResolverAttribute(Type valueResolver)
        {
            ValueResolver = valueResolver.GetConstructors()[0].Invoke(new object[] {}) as IValueResolver;
        }
    };
}
