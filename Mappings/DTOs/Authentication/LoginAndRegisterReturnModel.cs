using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.DTOs.Authentication
{
    public class LoginAndRegisterReturnModel
    {

        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string? RefreshToken { get; set; }
        public List<string> Roles { get; set; }
    }
}
