using System.Linq;
using System.Reflection;
using AutoMapper;

namespace AttributesForAutomapper
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Ignore all proprties that have AttributesForAutomapper.IgnoreMapAttribute
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoIgnoreMapAttribute(this IMappingExpression expression)
        {
            foreach (var property in
                expression.TypeMap.DestinationType.GetProperties()
                .Where(x => x.GetCustomAttribute<IgnoreMapAttribute>() != null))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }


        /// <summary>
        /// Assign mapping for properties that have different names 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoMapForMemberAttribute(this IMappingExpression expression)
        {
            var ok =
                from p in expression.TypeMap.DestinationType.GetProperties()
                let attr = p.GetCustomAttribute<MapForMemberAttribute>()
                where attr != null
                select new {AttributeValue = attr, PropertyName = p.Name};

             foreach (var property in ok)
             {
                 expression.ForMember(property.PropertyName, 
                     opt => opt.MapFrom(property.AttributeValue.MemberToMap));
             }
            return expression;
        }

        /// <summary>
        /// If IgnoreAllNonExistingProperty == true then ignore all unmapped properties.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoIgnoreAllNonExisting(this IMappingExpression expression)
        {
            var attr = expression.TypeMap.DestinationType.GetCustomAttribute<MapFromAttribute>();
            
            if (attr?.IgnoreAllNonExistingProperty == false)//instead of if(attr == null || attr.IgnoreAllNonExistingProperty == false)
                return expression;
            
            foreach (var property in expression.TypeMap.GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }

        /// <summary>
        /// Set defined 'IValueResolver' to property
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression DoUseValueResolverAttribute(this IMappingExpression expression)
        {
            var ok =
                from p in expression.TypeMap.DestinationType.GetProperties()
                let attr = p.GetCustomAttribute<UseValueResolverAttribute>()
                where attr != null
                select new {AttributeValue = attr, PropertyName = p.Name};

            foreach (var property in ok)
            {
                expression.ForMember(property.PropertyName,
                    opt => opt.ResolveUsing(property.AttributeValue.ValueResolver));
            }
            return expression;
        }

    }
}
