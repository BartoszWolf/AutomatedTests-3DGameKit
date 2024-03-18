using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class LoadLevelTests : SetupDisconnectClient
    {
        [Test]
        public void Level2()
        {
            //CALL METHOD THAT IS STORED IN PATH CLASS
            Level2Teleport();

            //ASSERTION TO CHECK WHETHER CORRECT LEVEL HAS BEEN LOADED
            Assert.That(api.GetSceneName() == "Level2", "Wrong level was loaded!");

            //SCREENSHOT TAKEN TO ENSURE TEST OUTPUT
            api.CaptureScreenshot(Screenshot("Level2Launch"), false, true);
        }
    }
}
