using gdio.unity_api.v2;
using NUnit.Framework;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class KeyboardConnectionVerificationTests : SetupCloseApplication
    {
        [Test]
        public void KeyboardCheck()
        {
            //DECLARE BOOL CONDITION
            bool hooked;

            //IF-STATEMENT TO VALIDATE WHETHER KEYBOARD IS CONNECTED
            if(api.EnableHooks(HookingObject.KEYBOARD))
            {
                hooked = true;
            }
            else
            {
                hooked = false;
            }

            //ASSERTION TO CHECK WHETHER THE KEYBOARD IS CONNECTED
            Assert.That(hooked, Is.True, "Keyboard is not connected");
        }
    }
}
