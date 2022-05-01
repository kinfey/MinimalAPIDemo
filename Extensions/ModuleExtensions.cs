namespace MinimalAPI.Extensions;


using System;
using System.Collections.Generic;


public static class ModuleExtensions
{

    static readonly List<IBaseModule> moduleList = new List<IBaseModule>(); 

    private static IEnumerable<IBaseModule> GetModules()
    {
        
        var modules = typeof(IBaseModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IBaseModule)))
            .Select(Activator.CreateInstance)
            .Cast<IBaseModule>();

        return modules;
    }

    public static void Routers(this IEndpointRouteBuilder builder)
    {

        foreach(var module in moduleList)
        {
            module.AddModuleRoutes(builder);
        }

    }

    public static void AddIoC(this IServiceCollection services)
    {

        foreach(var module in GetModules())
        {
            module.AddModuleIoC(services);
            moduleList.Add(module);
        }

    }

    public static void AddGlobalConfig(this IServiceCollection services)
    {
        services.AddScoped<CourseDataContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

}