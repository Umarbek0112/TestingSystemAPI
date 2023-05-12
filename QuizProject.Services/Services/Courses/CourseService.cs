using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Users;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Users;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseForViewDTOs> CreateAsync(CourseForCreateDTOs courseForCreateDTO)
        {
            var course = await _unitOfWork.Course.GetAsync(x => x.Name == courseForCreateDTO.Name);
            if (course != null)
                throw new QuizProjectException(404, "course is available");

            course = _mapper.Map<Course>(courseForCreateDTO);
            course.CreateAt = DateTime.UtcNow;
            var createAtCourse = await _unitOfWork.Course.CreateAsync(course);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CourseForViewDTOs>(createAtCourse);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _unitOfWork.Course.GetAsync(x => x.Id == id);
            if (course == null)
                throw new QuizProjectException(404, "Course not found");

            var deleteResult = await _unitOfWork.Course.DeleteAsync(course.Id);
            await _unitOfWork.SaveChangesAsync();

            return deleteResult;
        }

        public IEnumerable<CourseForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
            => _mapper.Map<IEnumerable<CourseForViewDTOs>>(
                _unitOfWork.Course.GetAll(expression, isTracking: false)
                .Include(quiz => quiz.Quizs).ThenInclude(ques => ques.Questions).ThenInclude(x => x.Attachment)
                .Include(quiz => quiz.Quizs).ThenInclude(ques => ques.Questions).ThenInclude(x => x.Answers)
                .Include(a => a.Quizs).ThenInclude(s => s.QuizResults).ThenInclude(d => d.User)
                .ToPagedList(@params));
        
        public async Task<CourseForViewDTOs> GetAsync(Expression<Func<Course, bool>> expression)
        {
            var course = await _unitOfWork.Course.GetAsync(expression, isTracking: false);
            if (course is null)
                throw new QuizProjectException(404, "Course not found");

            return _mapper.Map<CourseForViewDTOs>(course);
        }
    }
}
