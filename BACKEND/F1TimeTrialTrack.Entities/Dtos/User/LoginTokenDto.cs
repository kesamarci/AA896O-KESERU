using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.User
{
    public class LoginTokenDto
    {
        public string Token { get; set; } = "";

        public DateTime Expiration { get; set; }
    }
}
