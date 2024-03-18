using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class ActivateSwitchTests : SetupDisconnectClient
    {
        [Test]
        public void Activate()
        {
            //TELEPORT TO LEVEL2
            Level2Teleport();

            //VECTOR3 TO STORE SWITCH POSITION
            Vector3 switchPosition = api.GetObjectPosition("//*[@name='Switch3']");

            //BOOL TO STORE AUDIO AFTER SWITCH VALUE BEFORE CHANGE
            bool ifBefore = api.GetObjectFieldValue<bool>("//*[@name='AudioAfterSwitch']/fn:component('UnityEngine.AudioSource')/@isPlaying");

            //TELEPORT TO SWITCH POSITION LOCATION
            SetObjectPosition(switchPosition);

            //BOOL TO STORE AUDIO AFTER SWITCH VALUE AFTER CHANGE 
            bool ifAfter = api.GetObjectFieldValue<bool>("//*[@name='AudioAfterSwitch']/fn:component('UnityEngine.AudioSource')/@isPlaying");

            //ASSERT TO CHECK IF AUDIO SWITCH VALUE DIFFERS
            Assert.That(ifBefore != ifAfter, "Switch hasnt changed its state");
        }

        //METHOD TO SET AND CORRECT CHARACTER POSITION
        public void SetObjectPosition(Vector3 HPath)
        {
            HPath.x -= 1;
            HPath.z -= 1;
            api.SetObjectFieldValue(ellenPosition, position, HPath);
        }
    }
}
