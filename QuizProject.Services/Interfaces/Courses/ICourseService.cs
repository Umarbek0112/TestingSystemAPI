using QuizProject.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Domain.Entities.Courses;

namespace QuizProject.Service.Interfaces.Courses
{
    public interface ICourseService
    {
        IEnumerable<CourseForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
        Task<CourseForViewDTOs> GetAsync(Expression<Func<Course, bool>> expression);
        Task<CourseForViewDTOs> CreateAsync(CourseForCreateDTOs courseForCreateDTO);
        Task<bool> DeleteAsync(int id);      
    }
}
