using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Project.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        HomeController h = new HomeController(null, null, null);
        [TestMethod()]
        public void SumTest()
        {
            Assert.AreEqual(25, h.Sum(20, 5));
        }
    }
}