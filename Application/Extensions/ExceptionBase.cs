using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public abstract class ExceptionBase : Exception
    {
        public virtual int StatusCode { get; protected set; } = 500;

        public ExceptionBase(string message) : base(message)
        {
        }
        public ExceptionBase()
        {
        }
    }
}
