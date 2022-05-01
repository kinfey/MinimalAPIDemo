
namespace MinimalAPI.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;


public interface IDatabaseFactory : IDisposable
{
    CourseDataContext Get();
}
