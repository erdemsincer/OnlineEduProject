using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.Dtos.LoginDtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }

    }
}
