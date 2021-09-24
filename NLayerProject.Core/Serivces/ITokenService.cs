using NLayerProject.Core.Dtos;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Serivces
{
    public interface ITokenService
    {
        TokenDto CreateTokenByUser(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
