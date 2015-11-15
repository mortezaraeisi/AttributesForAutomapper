using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AttributesForAutomapper.Convertors;

namespace AttributesForAutomapper
{
    public static class Configuration
    {
        public static void Initialize(Assembly assembly)
        {
            //register global convertors.
            AutoMapper.Mapper.CreateMap<DateTime, string>().ConvertUsing<DateTimeToPersianDateTimeConverter>();


            var typesToMap = from t in assembly.GetTypes()
                let attr = t.GetCustomAttribute<MapFromAttribute>()
                where attr != null
                select new {SourceType = attr.SourceType, Destination = t, Attribute = attr};

            foreach (var map in typesToMap)
            {
                AutoMapper.Mapper.CreateMap(map.SourceType, map.Destination)
                    
                    .DoMapForPropertyAttribute() // it must be the first

                    .DoMapForPropertyAttribute() // for different property names in source and destination

                    .DoIgnoreAttribute()// ignore specified properties

                    .DoUseValueResolverAttribute()// set value resolvers

                    .DoIgnoreAllNonExisting()// its have to be the latest.
                    ;

            } //endeach

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    };
}
