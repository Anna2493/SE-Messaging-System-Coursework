using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ConcreteSirEmail : AbstractMessageProduct
    {
        public ConcreteSirEmail(string type, 
                                string sender, 
                                string body, 
                                string sirSubject,
                                string centreCode,
                                string incidentNature)
        {
            base._type = type;
            base._sender = sender;
            base._body = body;
            base._sirSubject = sirSubject;
            base._centreCode = centreCode;
            base._incidentNature = incidentNature;
        }
    }
}
