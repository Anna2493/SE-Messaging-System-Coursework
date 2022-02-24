using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ConcreteSmsMessage : AbstractMessageProduct
    {
        public ConcreteSmsMessage(string type, string sender, string body)
        {
            base._type = type;
            base._sender = sender;
            base._body = body;
        }

    }


}
