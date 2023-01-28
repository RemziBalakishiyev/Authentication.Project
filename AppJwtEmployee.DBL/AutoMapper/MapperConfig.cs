using AppJwtEmployee.DBL.AutoMapper.Abstract;
using AutoMapper;
using System.Reflection;
using System.Reflection.Metadata;

namespace AppJwtEmployee.DBL.AutoMapper;

public sealed class Map
{
    public Type Source { get; set; }
    public Type Destination { get; set; }
}
public class MapperConfig : Profile
{
    public static IMapperConfigurationExpression MapperConfigurationExpression = null;

    public MapperConfig()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var mapsFrom = LoadCustomMappings(assembly);
        foreach (var map in mapsFrom)
        {
            map.CreateMappings(this);
        }

        var mapsTo = LoadStandardMappings(assembly);

        foreach (var map in mapsTo)
        {
            CreateMap(map.Source, map.Destination).ReverseMap();
        }
    }



    private static IList<Map> LoadStandardMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
            from type in types
            from instance in type.GetInterfaces()
            where
                instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                !type.IsAbstract &&
                !type.IsInterface
            select new Map
            {
                Source = type.GetInterfaces().First().GetGenericArguments().First(),
                Destination = type
            }).ToList();

        return mapsFrom;
    }


    private static IList<IHaveCustomMappings> LoadCustomMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
            from type in types
            from instance in type.GetInterfaces()
            where
                typeof(IHaveCustomMappings).IsAssignableFrom(type) &&
                !type.IsAbstract &&
                !type.IsInterface
            select (IHaveCustomMappings)Activator.CreateInstance(type)).ToList();

        return mapsFrom;
    }
   
}
interface IHaveCustomMappings
{
    void CreateMappings(Profile configuration);
}
