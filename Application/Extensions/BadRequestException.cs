using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public class BadRequestException : ExceptionBase
    {
        public override int StatusCode { get; protected set; } = 400;

        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException()
        {
        }
    }
}
