using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Configuration
{
    public class CustomTokenOption
    {
        public List<string> Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpirations { get; set; }
        public int RefreshTokenExpirations { get; set; }
        public string SecurityKey { get; set; }
    }
}
