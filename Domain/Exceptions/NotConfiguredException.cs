using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotConfiguredException : Exception
    {
        public NotConfiguredException()
        {
        }
        public NotConfiguredException(string message) : base(message)
        {
        }
        public NotConfiguredException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
