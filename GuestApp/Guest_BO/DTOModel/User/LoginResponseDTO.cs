using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BO.DTOModel.User
{
    public class LoginResponseDTO
    {
        public UserDTO user { get; set; }
        public string role { get; set; }
        public string Token { get; set; }
    }
}
