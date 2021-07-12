using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Responses
{
    public class ErrorResponse
    {
        public List<ErroModel> Errors { get; set; } = new List<ErroModel>();
    }
}
