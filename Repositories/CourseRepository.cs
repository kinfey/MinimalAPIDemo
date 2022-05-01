namespace MinimalAPI.Repositories;

using System;

public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(CourseDataContext context)
        : base(context)
    {
    }
}
public interface ICourseRepository : IRepository<Course>
{

}


