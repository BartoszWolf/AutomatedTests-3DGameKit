using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes.UI
{
    [TestFixture, Order(0)]
    public class EnterMenuTests : SetupCloseApplication
    {
        [Test]
        public void EnteringMenu()
        {
            //WAIT FOR ELLEN
            api.WaitForObject("//*[@name='Ellen']");
            api.Wait(2000);

            //CHECK IF LEVEL IS LOADED
            ClassicAssert.AreEqual(api.GetSceneName(), "Level1", "Level didnt load.");

            //OPEN PAUSE MENU
            api.SetObjectFieldValue("//*[@name='PauseCanvas']", "active", true);

            //CHECK IF PAUSE MENU IS OPEN
            bool isOpen = api.GetObjectFieldValue<bool>("//*[@name='PauseCanvas']/@active");
            ClassicAssert.IsTrue(isOpen, "Menu is not open.");
        }
    }
}
