using NLayerProject.Core.Dtos;
using SharedLibrary.Dtos;
using SharedLibrary.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Serivces
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenForUser(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoContent>> RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDto> CreateTokenForClient(ClientLoginDto clientLoginDto);
    }
}
