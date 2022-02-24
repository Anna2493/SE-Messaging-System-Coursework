using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MessageTypeFactory
    {
        string _type;
        string _sender;
        string _body;
        string _standardSubject;
        string _sirSubject;
        string _centreCode;
        string _incidentNature;
        string _tweetId;
        string _tweetBody;

        public AbstractMessageProduct FactoryMethod(string Type, 
                                                    string Sender, 
                                                    string Body,
                                                    string StandardSubject,
                                                    string SirSubject,
                                                    string CentreCode,
                                                    string IncidentNature,
                                                    string TweetId,
                                                    string TweetBody)
        {

            if(Type == "Sms")
            {
                _type = Type;
                _sender = Sender;
                _body = Body;

                return new ConcreteSmsMessage(_type, _sender, _body);
            }
            else if(Type == "Standard email")
            {
                _type = Type;
                _sender = Sender;
                _standardSubject = StandardSubject;
                _body = Body;

                return new ConcreteStandardEmail(_type, _sender, _standardSubject, _body);
            }
            else if(Type == "SIR")
            {
                _type = Type;
                _sender = Sender;
                _sirSubject = SirSubject;
                _centreCode = CentreCode;
                _incidentNature = IncidentNature;
                _body = Body;

                return new ConcreteSirEmail(_type, _sender, _sirSubject, _centreCode, _incidentNature, _body);
            }
            else if (Type == "Tweet")
            {
                _type = Type;
                _tweetId = TweetId;
                _tweetBody = TweetBody;

                return new ConcreteTweet(_type, _tweetId, _tweetBody);
            }
            else
            {
                return null;
            }



        }
    }
}
