using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Users;
using QuizProject.Service.DTOs.Users;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace QuizProject.Service.Interfaces.Users
{
    public interface IUserService
    {
        IEnumerable<UserForViewDTOs> GetAll(PaginationParams @params, Expression<Func<User, bool>> expression = null);
        Task<UserForViewDTOs> GetAsync(Expression<Func<User, bool>> expression);
        Task<UserForCreateDTOs> CreateAsync(UserForCreateDTOs userForCreateDTOs);
        Task<bool> DeleteAsync(int id);
        Task<UserForViewDTOs> UpdateAsync(int id, UserForUpdateDTOs userForUpdateDTOs);
    }
}
