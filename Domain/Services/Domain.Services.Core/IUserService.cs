using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IUserService
    {
        GenericServiceResponse<IEnumerable<UserDto>> GetAllUsers();

        GenericServiceResponse<UserDto> FindUserById(int Id);

        GenericServiceResponse<bool> CreateUser(UserDto user);

        GenericServiceResponse<bool> UpdateUser(UserDto user);

        GenericServiceResponse<bool> DeleteUser(UserDto user);

        GenericServiceResponse<bool> DeleteUser(int Id);
    }
}