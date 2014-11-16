

using System;

namespace GalaxyUnitTests
{
    using GalaxyGuide.Common;
    using GalaxyGuide.Server;
    using NUnit.Framework;

    [TestFixture]
    public class GalacticalUnitTests
    {
        private readonly GalaxyManager _manager = new GalaxyManager();

        [TestCase(Description = "Assign invalid Roamns to any new keywords Test Cases")]
        public void AssignInvalidWord()
        {

            //Invalid roman test
            var result = _manager.ProcessMessage("globe is O");
            Assert.AreEqual(Constants.NoIdea, result);


            //Invalid roman test
            result = _manager.ProcessMessage("Hellow billy");
            Assert.AreEqual(Constants.NoIdea, result);
        }

        [TestCase(Description = "Assign Roamns to any new keywords Test Cases")]
        public void AssignWord()
        {

            //Valid roman test
            var result = _manager.ProcessMessage("globe is X");
            Assert.AreEqual(Constants.Assigned, result);

            //Valid roman test
            result = _manager.ProcessMessage("pork is L");
            Assert.AreEqual(Constants.Assigned, result);

            //Valid roman test
            result = _manager.ProcessMessage("mango is M");
            Assert.AreEqual(Constants.Assigned, result);


        }

        [TestCase(Description = "Updating the key word if already exists.")]
        public void UpdateWord()
        {
            //Valid roman update test
            var result = _manager.ProcessMessage("mango is D");
            Assert.AreEqual(Constants.Assigned, result);

            //Valid roman update test
            result = _manager.ProcessMessage("pork is D");
            Assert.AreEqual(Constants.Assigned, result);

        }

        [TestCase(Description ="Test invalid galctical values already saved")]
        public void GetInvalidGlacticValues()
        {
            //Valid roman update test
            var result = _manager.ProcessMessage("pork is I");
            Assert.AreEqual(Constants.Assigned, result);

            //InValid Get Glactic Values
            Assert.Throws<Exception>(() => _manager.ProcessMessage("how much is pork pork pork pork?"))
                .Message.Equals(Constants.InvalidRoamnsCombination);}

        [TestCase(Description = "Test valid galctical values already saved")]
        public void GetGlacticValues()
        {
            //Valid roman update test
            var result = _manager.ProcessMessage("pork is D");
            Assert.AreEqual(Constants.Assigned, result);

            //Valid Get Glactic Values
            result = _manager.ProcessMessage("how much is pork?");
            Assert.AreEqual("pork is 500", result);

            //Valid Get Glactic Values
            result = _manager.ProcessMessage("how much is cock?");
            Assert.AreEqual(Constants.InvalidUnits, result);
        }
    }
}
