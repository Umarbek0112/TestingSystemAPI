using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Users;
using QuizProject.Service.DTOs.Users;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserForCreateDTOs> CreateAsync(UserForCreateDTOs userForCreateDTOs)
        {
            var crateatUser = await _unitOfWork.User.GetAsync(x => x.Email == userForCreateDTOs.Email);
            if (crateatUser != null)
                throw new QuizProjectException(404, "Email is available");

            crateatUser = _mapper.Map<User>(userForCreateDTOs);
            crateatUser.CreateAt = DateTime.UtcNow;
            await _unitOfWork.User.CreateAsync(crateatUser);
            await _unitOfWork.SaveChangesAsync();

            return userForCreateDTOs;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedUser = await _unitOfWork.User.GetAsync(x => x.Id == id);
            if (deletedUser is null)
                throw new QuizProjectException(404, "User not found");

            var deleteResult = await _unitOfWork.User.DeleteAsync(deletedUser.Id);
            await _unitOfWork.SaveChangesAsync();

            return deleteResult;
        }

        public IEnumerable<UserForViewDTOs> GetAll(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        => _mapper.Map<IEnumerable<UserForViewDTOs>>(
                _unitOfWork.User.GetAll(expression, isTracking: false)
                .Include(x => x.QuizResualts).ThenInclude(r => r.Test).ThenInclude(co => co.Course)
                .Include(x => x.QuizResualts).ThenInclude(r => r.Test).ThenInclude(q => q.Questions).ThenInclude(z => z.Answers)
                .Include(x => x.QuizResualts).ThenInclude(r => r.Test).ThenInclude(q => q.Questions).ThenInclude(z => z.Attachment)
                .ToPagedList(@params));

        public async Task<UserForViewDTOs> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await _unitOfWork.User.GetAsync(expression, isTracking: false);
            if (user is null)
                throw new QuizProjectException(404, "User not found");

            return _mapper.Map<UserForViewDTOs>(user);
        }

        public async Task<UserForViewDTOs> UpdateAsync(int id, UserForUpdateDTOs userForUpdateDTOs)
        {
            var updatedUser = await _unitOfWork.User.GetAsync(x => x.Id == id);
            if (updatedUser == null)
                throw new QuizProjectException(404, "Email is available");

            var alreadyExistUser = await _unitOfWork.User.GetAsync(
               u => u.Email == userForUpdateDTOs.Email && u.Id != id);

            if (alreadyExistUser != null)
                throw new QuizProjectException(400, "User with such email already exists");

            updatedUser.UpdateAt = DateTime.UtcNow;
            _unitOfWork.User.Update(_mapper.Map(userForUpdateDTOs, updatedUser));
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserForViewDTOs>(updatedUser);
        }
    }
}
