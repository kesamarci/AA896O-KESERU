using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Helpers
{
    public class Error
    {
        public string Message { get; set; } = "";

        public Error(string message)
        {
            Message = message;
        }
    }
}
