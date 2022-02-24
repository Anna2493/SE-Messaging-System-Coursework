using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesti
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "S";

        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWritter())
            {
                Console.SetOut(sw);

            }
        }
    }
}
