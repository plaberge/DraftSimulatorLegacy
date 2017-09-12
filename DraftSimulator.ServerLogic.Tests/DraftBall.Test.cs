using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftSimulator.ServerLogic;
using System.Threading.Tasks;

namespace DraftSimulator.ServerLogic.Tests
{
    [TestClass]
    public class DraftBallTest
    {
        [TestMethod]
        [TestCategory("ForBuild")]
        public void DraftBallConstructor_Test()
        {
            // Arrange Variables
            DraftBall draftball = new DraftBall();
            bool BallValueGreater = (draftball.DraftBallNumber[0] > 0);
            bool BallValueLesser = (draftball.DraftBallNumber[0] < 15);
            // Assertions
            Assert.AreEqual(BallValueGreater, true,"Draftball number less than 1.");
            Assert.AreEqual(BallValueLesser, true, "Draftball number greater than 14.");
        }

        [TestMethod]
        [TestCategory("ForBuild")]
        public void MultiDraftBallConstructor_Test()
        {
            DraftBall draftball = new DraftBall(4);
            bool BallValueGreater = (draftball.DraftBallNumber[0] > 0);
            bool BallValueLesser = (draftball.DraftBallNumber[0] < 15);

            for (int i=0; i < 4; i++)
            {
                BallValueGreater = draftball.DraftBallNumber[i] > 0;
                BallValueLesser = draftball.DraftBallNumber[i] < 15;

                //Assertions
                Assert.AreEqual(BallValueGreater, true, "Draftball number less than 1.");
                Assert.AreEqual(BallValueLesser, true, "Draftball number greater than 14.");
                Console.Write("Position {0} value is {1}.\n", i, draftball.DraftBallNumber[i]);
            }
        }

        //[TestMethod]
        //public async Task DraftRunLocation_Test()
        //{
        //    string IPAddress;

        //    IPAddress = "27.0.44.3";
        //    DraftRunLocation drl = new DraftRunLocation();
        //    await drl.GetJSONResponse(IPAddress);
        //    Assert.IsNotNull(drl);

        //}
    }
}
