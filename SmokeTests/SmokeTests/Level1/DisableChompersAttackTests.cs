using NUnit.Framework;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class DisableChompersAttackTests : SetupCloseApplication
    {
        [Test]
        public void Disarming()
        {
            //CALL METHOD THAT IS STORED IN PATH CLASS
            DisarmEnemies();
        }
    }
}
