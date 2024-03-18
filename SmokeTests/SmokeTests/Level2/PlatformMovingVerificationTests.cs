using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class PlatformMovingVerificationTests : SetupDisconnectClient
    {
        [Test]
        public void PlatformIsMoving()
        {
            //CALL METHOD THAT IS STORED IN PATH CLASS
            Level2Teleport();

            //STORE PLATFORM'S PATH
            string platformName = "//*[@name='MovingPlatform'][0]";

            //VECTOR3 TO STORE PLATFORM'S INITIAL POSITION
            Vector3 initPlatformPosition = api.GetObjectFieldValue<Vector3>("(//*[@name='GameObject'])[4]/fn:component('UnityEngine.Transform')/@localPosition");

            //WAIT FOR 2 SECONDS
            api.Wait(2000);

            //VECTOR3 TO STORE PLATFORM'S POSITION AFTER A WHILE
            Vector3 afterPlatformPosition = api.GetObjectFieldValue<Vector3>("(//*[@name='GameObject'])[4]/fn:component('UnityEngine.Transform')/@localPosition");

            //CHECK IF THE PLATFORM'S POSITION HAS CHANGED
            Assert.That(initPlatformPosition, Is.Not.EqualTo(afterPlatformPosition), $"Platform {platformName} didnt move.");
        }
    }
}
