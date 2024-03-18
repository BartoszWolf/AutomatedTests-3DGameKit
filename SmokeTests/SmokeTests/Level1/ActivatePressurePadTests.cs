using gdio.common.objects;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class ActivatePressurePadTests : SetupCloseApplication
    {
        [Test]
        public void PressurePad()
        {
            //TELEPORT CHARACTER TO POSITION OF PRESSURE PAD
            api.SetObjectFieldValue(ellenPosition, position, ReturnVector3(api.GetObjectFieldValue<Vector3>("//*[@name='PressurePad1']/fn:component('UnityEngine.Transform')/@position")));

            //WAIT FOR THE TIME OF SEQUENCE DURATION
            api.Wait((int)api.GetObjectFieldValue<double>("//*[@name='Level01_Sequence01']/fn:component('UnityEngine.Playables.PlayableDirector')/@duration") * 1000);

            //CHECK IF THE DOORS ARE OPEN USING CLASSIC ASSERT CLASS
            ClassicAssert.AreNotEqual(ReturnVector3(api.GetObjectFieldValue<Vector3>(doorHugePosition + "/@end")), ReturnVector3(api.GetObjectFieldValue<Vector3>(doorHugePosition + "/@start")));
            ClassicAssert.AreEqual(ReturnVector3(api.GetObjectFieldValue<Vector3>(doorHugePosition + "/@end")), ReturnVector3(api.GetObjectFieldValue<Vector3>(doorHugePosition + "/@end")));
        }
    }
}
