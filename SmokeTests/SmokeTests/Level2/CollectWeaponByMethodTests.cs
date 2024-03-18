using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class CollectWeaponByMethodTests : SetupCloseApplication
    {
        [Test]
        public void GainWeapon()
        {
            //CALL METHODS THAT ARE STORED IN PATH CLASS
            Level2Teleport();
            WeaponActive();
        }
    }
}
