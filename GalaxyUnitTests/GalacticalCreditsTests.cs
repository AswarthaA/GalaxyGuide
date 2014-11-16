
namespace GalaxyUnitTests
{
    using GalaxyGuide.Common;
    using GalaxyGuide.Server;
    using NUnit.Framework;

    [TestFixture]
    public class GalacticalCreditsTests
    {
        readonly GalaxyManager _manager = new GalaxyManager();

        [TestCase(Description = "Calculate credits with invalid keywords")]
        public void InvalidCredits()
        {
            //Invalid credit assignment
            var result = _manager.ProcessMessage("mango mango box is 40 credits");
            Assert.AreEqual(Constants.NoUnits, result);

            //Invalid credit assignment
            result = _manager.ProcessMessage("mango mango X is 40 credits");
            Assert.AreEqual(Constants.NoUnits, result);

            //Valid roman update test
            result = _manager.ProcessMessage("mango is X");
            Assert.AreEqual(Constants.Assigned, result);

            //Valid roman update test
            result = _manager.ProcessMessage("pork is V");
            Assert.AreEqual(Constants.Assigned, result);


            //Invalid credit assignment
            result = _manager.ProcessMessage("mango test silver is 40 credits");
            Assert.AreEqual(Constants.InvalidUnits, result);

            //Invalid credit assignment
            // more space is given between pork and is, it will not recognize the space.
            result = _manager.ProcessMessage("mango pork   is 40 credits");
            Assert.AreEqual(Constants.NoIdea, result);

        }

        [TestCase(Description = "Calculate credits with invalid keywords")]
        public void ValidCredits()
        {
            //Valid roman update test
            var result = _manager.ProcessMessage("mango is I");
            Assert.AreEqual(Constants.Assigned, result);

            //Valid roman update test
            result = _manager.ProcessMessage("pork is V");
            Assert.AreEqual(Constants.Assigned, result);

            //Invalid credit assignment
            result = _manager.ProcessMessage("mango mango box is 40 credits");
            Assert.AreEqual(Constants.CreditsAssigned, result);

            
        }


    }
}
