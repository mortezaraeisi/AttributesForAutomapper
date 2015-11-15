using System;

namespace AttributesForAutomapper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapForMemberAttribute : Attribute
    {
        public string MemberToMap { get; private set; }

        public MapForMemberAttribute(string memberToMap)
        {
            MemberToMap = memberToMap;
        }
    };
}
