using NLayerProject.Core.Dtos;
using SharedLibrary.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Serivces
{
    public  interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByEmailAsync(string email);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
