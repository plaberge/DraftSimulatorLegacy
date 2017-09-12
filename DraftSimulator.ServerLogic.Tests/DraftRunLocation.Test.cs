using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftSimulator.ServerLogic;
using System.Threading.Tasks;

namespace DraftSimulator.ServerLogic.Tests
{
    [TestClass]
    public class DraftRunLocationTest
    {
        [TestMethod]
        [TestCategory("Not_ForBuild")]
        public async Task DraftRunLocation_Test()
        {
            string IPAddress;

            IPAddress = "27.0.44.3";
            DraftRunLocation drl = new DraftRunLocation();
            await drl.GetJSONResponse(IPAddress);
            Assert.IsNotNull(drl.Country, "Country Value is NULL");
            Assert.IsNotNull(drl.City, "City Value is NULL");
            Assert.IsNotNull(drl.Latitude, "Latitude Value is NULL");
            Assert.IsNotNull(drl.Longitude, "Longitude Value is NULL");

        }


    }
}
