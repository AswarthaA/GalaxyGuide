

namespace GalaxyUnitTests
{
    using System;
    using GalaxyGuide.Common;
    using GalaxyGuide.Server;
    using NUnit.Framework;

    [TestFixture]
    public class RomanNumberTest
    {
        private readonly GalaxyManager _manager = new GalaxyManager();

        [TestCase(Description = "Invalid roman number tests")]
        public void InvalidRomanTests()
        {
            //invalid combination
            Assert.Throws<Exception>(() => _manager.ProcessMessage("MMMM"))
                .Message.Equals(Constants.InvalidRoamnsCombination);

            //Invalid roman test
            var result = _manager.ProcessMessage("IIII");
            Assert.AreEqual(Constants.NoIdea, result);

            //Invalid roman test
            result = _manager.ProcessMessage("XVVV");
            Assert.AreEqual(Constants.NoIdea, result);

            //Invalid roman test
            result = _manager.ProcessMessage("VVDD");
            Assert.AreEqual(Constants.NoIdea, result);
        }

        [TestCase(Description = "Invalid roman number tests")]
        public void ValidRomanTests()
        {
            //Valid roman test
            var result = _manager.ProcessMessage("III");
            Assert.AreEqual("3", result);

            //Valid roman test
            result = _manager.ProcessMessage("XLV");
            Assert.AreEqual("45", result);
        }
    }
}
