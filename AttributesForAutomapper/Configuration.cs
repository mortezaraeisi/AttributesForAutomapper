using System;
using System.Linq;
using System.Reflection;
using AttributesForAutomapper.Convertors;
using AutoMapper;

namespace AttributesForAutomapper
{
    public static class Configuration
    {
        public static void Initialize(Assembly assembly)
        {
            //register global convertors.
            Mapper.CreateMap<DateTime, string>().ConvertUsing<DateTimeToPersianDateTimeConverter>();


            var typesToMap = from t in assembly.GetTypes()
                let attr = t.GetCustomAttribute<MapFromAttribute>()
                where attr != null
                select new {SourceType = attr.SourceType, Destination = t, Attribute = attr};

            foreach (var map in typesToMap)
            {
                Mapper.CreateMap(map.SourceType, map.Destination)
                    
                    .DoMapForMemberAttribute() // for different property names in source and destination

                    .DoIgnoreMapAttribute()// ignore specified properties

                    .DoUseValueResolverAttribute()// set value resolvers

                    .DoIgnoreAllNonExisting()// its have to be the latest.
                    ;

            } //endeach

            Mapper.AssertConfigurationIsValid();
        }
    };
}
