using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class GameLaunchTests : SetupCloseApplication
    {
        [Test]
        public void Launch()
        {
            //VALIDATE WHETHER CORRECT LEVEL WAS LOADED
            Assert.That(api.GetSceneName() == "Level1", "Wrong level was loaded!");

            //SCREENSHOT TO ENSURE THE RESULT
            api.CaptureScreenshot(Screenshot("GameLaunch"), false, true);
        }
    }
}
