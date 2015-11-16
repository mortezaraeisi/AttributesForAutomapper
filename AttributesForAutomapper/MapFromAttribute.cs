using System;

namespace AttributesForAutomapper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MapFromAttribute : Attribute
    {
        public Type SourceType { get; private set; }
        public bool IgnoreAllNonExistingProperty { get; private set; }
        public bool AlsoCopyMetadata { get; private set; }
        //Go to: http://www.dotnettips.info/courses/topic/16/cb36bc2e-4263-431e-86a5-236322cb5576

        public MapFromAttribute(Type sourceType, bool ignoreAllNonExistingProperty = false,
            bool alsoCopyMetadata = false)
        {
            SourceType = sourceType;
            IgnoreAllNonExistingProperty = ignoreAllNonExistingProperty;
            AlsoCopyMetadata = alsoCopyMetadata;
        }
    };
}
