using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Async_Inn.Interfaces
{
    public interface IUserService
    {
        public Task Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password, ModelStateDictionary modelState);
    }
}
