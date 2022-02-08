using JacobPlateauMission;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JacobPlateauMissionTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestRover1()
        {
            var rover = new Rover
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };

            rover.ExploreJacobPlateau(new JacobPlateau { X = 5, Y = 5 }, "LMLMLMLMM");

            Assert.AreEqual("1 3 N", $"{rover.X} {rover.Y} {rover.Direction}");
        }

        [TestMethod]
        public void TestRover2()
        {

        }
    }
}
