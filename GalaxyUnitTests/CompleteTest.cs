/*
 *   FileName: CompleteTest.cs
 *   Class file: This file contains GalaxyManager all valid test scenarios.
 *   Author: Aswartha Narayana
 *   Date Created: 16th Nov 2014
 *   
 *   Copyright (c) 2014 All Rights Reserved.. :)
*/

namespace GalaxyUnitTests
{
    using GalaxyGuide.Common;
    using GalaxyGuide.Server;
    using NUnit.Framework;

    /// <summary>
    /// Test cases of GalaxyManager, all valid test scenarios.
    /// </summary>
    [TestFixture]
    public class CompleteTest
    {
        private readonly GalaxyManager _manager = new GalaxyManager();

        /// <summary>
        /// Test cases of GalaxyManager, all valid test scenarios.
        /// </summary>
        [TestCase(Description="Complete set of tests")]
        public void CompleteTests()
        {
            Assert.AreEqual(Constants.Assigned, _manager.ProcessMessage("glob is I"));
            Assert.AreEqual(Constants.Assigned, _manager.ProcessMessage("prok is V"));
            Assert.AreEqual(Constants.Assigned, _manager.ProcessMessage("pish is X"));
            Assert.AreEqual(Constants.Assigned, _manager.ProcessMessage("tegj is L"));
            Assert.AreEqual(Constants.CreditsAssigned, _manager.ProcessMessage("glob glob Silver is 34 Credits"));
            Assert.AreEqual(Constants.CreditsAssigned, _manager.ProcessMessage("glob prok Gold is 57800 Credits"));
            Assert.AreEqual(Constants.CreditsAssigned, _manager.ProcessMessage("pish pish Iron is 3910 Credits"));
            Assert.AreEqual("pish tegj glob glob is 42", _manager.ProcessMessage("how much is pish tegj glob glob ?"));
            Assert.AreEqual("glob prok Silver is 68 Credits", _manager.ProcessMessage("how many Credits is glob prok Silver ?"));
            Assert.AreEqual("glob prok Gold is 57800 Credits", _manager.ProcessMessage("how many Credits is glob prok Gold ?"));
            Assert.AreEqual("glob prok Iron is 782 Credits", _manager.ProcessMessage("how many Credits is glob prok Iron ?"));
            Assert.AreEqual(Constants.NoIdea, _manager.ProcessMessage("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
        }
    }
}
