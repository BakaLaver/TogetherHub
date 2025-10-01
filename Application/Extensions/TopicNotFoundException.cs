using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public class TopicNotFoundException : NotFoundException
    {
        public TopicNotFoundException(string message) : base(message)
        {

        }

        public TopicNotFoundException(Guid id) : base($"Топик с id ({id}) не найден")
        {

        }
    }
}
