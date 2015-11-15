using System;

namespace AttributesForAutomapper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapForMemberAttribute : Attribute
    {
        public string PropertyToMap { get; private set; }

        public MapForMemberAttribute(string propertyToMap)
        {
            PropertyToMap = propertyToMap;
        }
    };
}
