
namespace MinimalAPI.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;


public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private CourseDataContext dataContext;
    public IConfiguration Configuration { get; set; }
    public CourseDataContext Get()
    {
            
        return dataContext ?? (dataContext = new CourseDataContext());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
    
}
