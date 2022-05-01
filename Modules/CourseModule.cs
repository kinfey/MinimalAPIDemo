using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Modules;

public class CourseModule : IBaseModule
{


    public void AddModuleIoC(IServiceCollection services)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseTypeService, CourseTypeService>();
    }


    public void AddModuleRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Course/TypeList" ,()=> {
            
            return  "获取课程类型";
        });


        app.MapGet("/Course/GetCourse" ,()=> {
            
            return  "获取课程列表";
        });
    }


    // public void AddModuleRoutes(IEndpointRouteBuilder app)
    // {
    //     app.MapGet("/Course/TypeList" ,([FromServices] ICourseTypeService courseTypeService)=> {
            
    //         return  courseTypeService.GetCourseTypeList();
    //     });


    //     app.MapGet("/Course/GetCourse" ,([FromServices] ICourseService courseService , int typeID)=> {
            
    //         return  courseService.GetCourseList(typeID);
    //     });
    // }
}