using gdio.common.objects;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class HealthBoxHealing : SetupCloseApplication
    {
        [Test]
        public void CheckingHealthBox()
        {
            //SET CHARACTER'S HIT POINTS FROM 5 TO 3
            api.CallMethod(ellenDamagable, "set_currentHitPoints", new object[] { 3 });
            api.Wait(2000);

            //CONTAIN MAX HIT POINTS VALUE AND CURRENT HIT POINTS VALUE
            int maxHp = api.GetObjectFieldValue<int>(ellenDamagable + "/@maxHitPoints");
            int currentHP = api.GetObjectFieldValue<int>(ellenDamagable + "/@currentHitPoints");

            //TELEPORT TO HEALTH BOX
            Vector3 healthBox = ReturnVector3(api.GetObjectFieldValue<Vector3>("//*[@name='HealthCrate'][0]/fn:component('UnityEngine.Transform')/@position"));
            api.SetObjectFieldValue(ellenPosition, "position", new Vector3(healthBox.x - 1, healthBox.y, healthBox.z));
            api.Wait(2000);

            //VALIDATE WHETHER CHARACTER WAS HEALED
            ClassicAssert.AreNotEqual(currentHP, maxHp, "Ellen wasn't healed");
        }
    }
}
