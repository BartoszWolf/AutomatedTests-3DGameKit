using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes.UI
{
    [TestFixture, Order(4)]
    public class EnterControlsTests : SetupCloseApplication
    {
        [Test]
        public void GetIntoControls()
        {
            //EXIT MUSIC MENU
            api.Wait(2000);
            api.CallMethod("(//*[@name='UIButton'])[7]/fn:component('UnityEngine.UI.Button')", "Press");

            //ENTER CONTROLS MENU
            api.CallMethod("(//*[@name='UIButton'])[4]/fn:component('UnityEngine.UI.Button')", "Press");
            api.Wait(1000);

            //CHECK IF MENU IS OPEN
            ClassicAssert.IsTrue(api.GetObjectFieldValue<bool>("//*[@name='ControlCanvas']/@active"), "Control menu wasn't opened");
        }
    }
}
