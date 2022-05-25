using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Tests
{
    [TestClass()]
    public class StringToolTests
    {
        [TestMethod()]
        public void BuildStringTest()
        {
            StringTool.BuildString('a', 50);
            Assert.Fail();
        }
    }
}