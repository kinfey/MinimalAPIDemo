namespace MinimalAPI.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface ICourseTypeService
{
    IEnumerable<CourseType> GetCourseTypeList();
}
    
public class CourseTypeService : ICourseTypeService
{
    private readonly ICourseTypeRepository courseTypeRepository;
    private readonly IUnitOfWork unitOfWork;
        
    public CourseTypeService(ICourseTypeRepository courseTypeRepository, IUnitOfWork unitOfWork)
    {
        this.courseTypeRepository = courseTypeRepository;
        this.unitOfWork = unitOfWork;
    }

    public IEnumerable<CourseType> GetCourseTypeList()
    {
        return this.courseTypeRepository.GetAll();
    }

}