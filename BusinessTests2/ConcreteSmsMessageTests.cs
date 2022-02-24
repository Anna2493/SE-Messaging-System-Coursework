using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestClass()]
    public class ConcreteSmsMessageTests
    {
        [TestMethod()]
        public void ConcreteSmsMessageTest()
        {
            string expected = "Sms";

            ConcreteSmsMessage sms = new ConcreteSmsMessage("Sms", "+1234567890123", "This is sms body");

            sms.Type = "Sms";

            Assert.AreEqual(expected, sms.Type);
            

        }
    }
}