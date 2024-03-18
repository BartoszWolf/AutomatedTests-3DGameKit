using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes.UI
{
    [TestFixture, Order(5)]
    public class RestartGameTests : SetupCloseApplication
    {
        [Test]
        public void RestartingGame()
        {

            //BACK TO OPTION MENU
            ClassicAssert.IsTrue(api.GetObjectFieldValue<bool>("//*[@name='ControlCanvas']/@active"), "Controls menu wasn't opened");
            api.CallMethod("(//*[@name='UIButton'])[6]/fn:component('UnityEngine.UI.Button')", "Press");
            api.Wait(1000);

            //BACK TO PAUSE MENU
            ClassicAssert.IsTrue(api.GetObjectFieldValue<bool>("//*[@name='OptionsCanvas']/@active"), "Options menu wasn't opened");
            api.CallMethod("(//*[@name='UIButton'])[5]/fn:component('UnityEngine.UI.Button')", "Press");
            api.Wait(1000);


            //RESTAR LEVEL
            if (api.GetObjectFieldValue<bool>("//*[@name='PauseCanvas']/@active"))
            {
                api.CallMethod("(//*[@name='UIButton'])[1]/fn:component('UnityEngine.UI.Button')", "Press");
            }
        }
    }
}
