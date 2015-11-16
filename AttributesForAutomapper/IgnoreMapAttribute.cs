using System;

namespace AttributesForAutomapper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreMapAttribute : Attribute
    {
    };
}
