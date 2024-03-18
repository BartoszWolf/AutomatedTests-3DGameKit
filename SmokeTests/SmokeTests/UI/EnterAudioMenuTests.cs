using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes.UI
{
    [TestFixture, Order(2)]
    public class EnterAudioMenuTests : SetupCloseApplication
    {
        [Test]
        public void EnteringAudioMenu()
        {
            //WAIT FOR OPTION MENU
            api.WaitForObjectValue("//*[@name='OptionsCanvas']", "active", true);
            api.Wait(2000);

            //OPEN AUDIO MENU
            api.SetObjectFieldValue("//*[@name='AudioCanvas']", "active", true);

            //DISABLE OPTIONS MENU
            api.SetObjectFieldValue("//*[@name='PauseCanvas']", "active", false);

            //CHECK WHETHER THE AUDIO MENU IS OPEN
            bool isOpenAudio = api.GetObjectFieldValue<bool>("//*[@name='AudioCanvas']/@active");
            ClassicAssert.IsTrue(isOpenAudio, "Audio Menu is open.");
        }
    }
}
