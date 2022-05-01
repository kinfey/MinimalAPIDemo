
namespace MinimalAPI.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

public class UnitOfWork : IUnitOfWork
{
    private CourseDataContext dataContext;

    public UnitOfWork(CourseDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public void Commit()
    {
        this.dataContext.Commit();
    }
}
    
   