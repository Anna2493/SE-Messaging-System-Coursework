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
        public void detectMessageTypeTest()
        {
            // Arrange

            string messageHeader = "S";
            //string messageHeader2 = "E";
            //string messageHeader3 = "T";
            MainWindow header = new MainWindow();

            // Act

            header.detectMessageType();
            Assert.Fail();
        }
    }
}