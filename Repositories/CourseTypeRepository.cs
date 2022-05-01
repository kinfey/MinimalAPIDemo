namespace MinimalAPI.Repositories;

using System;

public class CourseTypeRepository : RepositoryBase<CourseType>, ICourseTypeRepository
{
    public CourseTypeRepository(CourseDataContext context)
        : base(context)
    {
    }
}
public interface ICourseTypeRepository : IRepository<CourseType>
{

}