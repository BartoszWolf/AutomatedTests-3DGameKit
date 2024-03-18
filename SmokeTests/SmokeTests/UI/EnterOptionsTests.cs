using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes.UI
{
    [TestFixture, Order(1)]
    public class EnterOptionsTests : SetupCloseApplication
    {
        [Test]
        public void EnteringOptions()
        {
            //OPEN OPTION MENU
            api.SetObjectFieldValue("//*[@name='OptionsCanvas']", "active", true);

            //DISABLE PAUSE MENU
            api.SetObjectFieldValue("//*[@name='PauseCanvas']", "active", false);

            //CHECK IF OPTION MENU IS OPEN
            bool isOpenOption = api.GetObjectFieldValue<bool>("//*[@name='OptionsCanvas']/@active");
            ClassicAssert.IsTrue(isOpenOption, "Option Menu is not open.");
        }
    }
}
