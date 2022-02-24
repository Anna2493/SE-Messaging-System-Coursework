using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ConcreteStandardEmail : AbstractMessageProduct
    {
        public ConcreteStandardEmail(string type, string sender, string body, string standardSubject)
        {
            base._type = type;
            base._sender = sender;
            base._body = body;
            base._standardSubject = standardSubject;
        }

    }
}
