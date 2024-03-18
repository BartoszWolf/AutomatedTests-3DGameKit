using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class OpenDoorsTests : SetupCloseApplication
    {
        //TESTCASES WITH ARGUMENTS
        [Test]
        [TestCase("//*[@name='PressurePad1']", 
            "//*[@name='PressurePad1']/fn:component('UnityEngine.Transform')/@position",
            "//*[@name='DoorHuge01']/fn:component('UnityEngine.Transform')/@position",
            "//*[@name='Door1']")]
        [TestCase("//*[@name='PressurePad2']",
            "//*[@name='PressurePad2']/fn:component('UnityEngine.Transform')/@position",
            "//*[@name='SmallDoor']/fn:component('UnityEngine.Transform')/@position",
            "//*[@name='SmallDoor']")]

        //DECLARATION OF ARGUMENTS SETTED IN TESTCASES
        public void PressurePadWorking(string pressPad, string pressPadPosition, string doorsPosition, string doorsName)
        {
            Level2Teleport();
            DoorsCheckerLogic(pressPad, pressPadPosition, doorsPosition, doorsName);
        }

        public void DoorsCheckerLogic(string pressPad, string pressPadPosition, string doorsPosition, string doorsName)
        {
            //WAIT FOR PLATFORM
            api.WaitForObject(pressPad);

            //VECTOR3 TO STORE DOORS POSITION
            Vector3 acctualPos = api.GetObjectFieldValue<Vector3>(doorsPosition);

            //TELEPORT PLAYER TO PRESSURE PAD POSITION
            Vector3 padPos = api.GetObjectFieldValue<Vector3>(pressPadPosition);
            padPos.y += 1;
            api.SetObjectFieldValue(ellen + componentTransform, position, padPos);

            //WAIT FOR CINEMATIC'S END
            api.Wait(8000);

            //VECTOR3 TO STORE DOORS END POSITION
            Vector3 endPos = api.GetObjectFieldValue<Vector3>(doorsPosition);

            //ASSERTION TO CHECK WHETHER THE ACCTUAL POSITION AND END POSITION DIFFERS
            Assert.That(acctualPos, Is.Not.EqualTo(endPos), $"Doors {doorsName} didnt open");
        }
    }
}
