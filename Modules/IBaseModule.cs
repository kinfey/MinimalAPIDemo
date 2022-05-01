namespace MinimalAPI.Modules;


using Microsoft.AspNetCore.Routing;

public interface IBaseModule
{
    void AddModuleRoutes(IEndpointRouteBuilder app);
    void AddModuleIoC(IServiceCollection services);

}