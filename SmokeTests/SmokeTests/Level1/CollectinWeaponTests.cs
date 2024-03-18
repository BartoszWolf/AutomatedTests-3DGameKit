using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class CollectinWeaponTests : SetupCloseApplication
    {
        [Test]
        public void CollectWeapon()
        {
            //VECTOR3 TO STORE START POSITION
            Vector3 startPos = api.GetObjectPosition(ellen);

            //CHECK IF WEAPON HAS SPAWNED
            bool weaponSpawned = (api.GetObjectFieldValue<bool>(staff1A));

            //IF WEAPON IS SPAWNED CALL THE METHOD TO TELEPORT
            if (weaponSpawned)
            {
                TeleportToStaff();
            }

            //WAIT FOR LOAD
            api.Wait(2000);

            //SCREENSHOT TAKEN AFTER TELEPORT
            api.CaptureScreenshot(Screenshot("WeaponCollect"), false, true);

            //CONDITION TO CHECK IF WEAPON WAS COLLECTED
            bool isTaken = api.GetObjectFieldValue<bool>(staff1A);
            Assert.That(isTaken, Is.True, $"Weapon {staff} is collected and active.");
        }
    }
}
