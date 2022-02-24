using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    abstract public class AbstractMessageProduct
    {
        protected string _type;
        protected string _sender;
        protected string _body;
        protected string _standardSubject;
        protected string _sirSubject;
        protected string _centreCode;
        protected string _incidentNature;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        public string StandardSubject
        {
            get { return _standardSubject; }
            set { _standardSubject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }      

        public string SirSubject
        {
            get { return _sirSubject; }
            set { _sirSubject = value; }
        }

        public string CentreCode
        {
            get { return _centreCode; }
            set { _centreCode = value; }
        }

        public string IncidentNature
        {
            get { return _incidentNature; }
            set { _incidentNature = value; }
        }


    }

}

