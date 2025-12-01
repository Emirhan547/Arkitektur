using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.TokenDtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
