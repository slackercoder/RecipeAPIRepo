using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeAPI;
using RecipeAPI.Controllers;

namespace RecipeAPI.Tests.Controllers
{
    [TestClass]
    class v1ControllerTests
    {
        v1Controller v1 = new v1Controller();

        [TestMethod]
        public void CreateMember_Pass()
        {
            String ret = v1.CreateNewMember("ThisNeedsARealKey");

            Assert.IsFalse(ret.Equals(String.Empty));
        }

        [TestMethod]
        public void CreateMember_Fail()
        {
            Assert.IsTrue(v1.CreateNewMember("ThisIsNotaRealApiKey").Equals(String.Empty));
        }
    }
}
