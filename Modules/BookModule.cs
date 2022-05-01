using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Modules;

public class BookModule : IBaseModule
{
    public void AddModuleIoC(IServiceCollection services)
    {
    }

    public void AddModuleRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Book/GetBookInfo" ,()=> {
            
            return  "选课信息";
        });
    }

}
