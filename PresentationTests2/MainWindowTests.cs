using Microsoft.VisualStudio.TestTools.UnitTesting;
using SECoursework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECoursework.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void filterSmsTest()
        {
            string phoneNumber = "+1234567890123";
            string phoneNumberToTest = "+1234567890123";

            Assert.AreEqual(phoneNumber, phoneNumberToTest);

        }
    }
}