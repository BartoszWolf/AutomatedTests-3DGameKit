using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class ActivateFirstPressurePadTests : SetupCloseApplication
    {
        [Test]
        public void ActivatePlatform()
        {
            //CALL METHODS THAT ARE STORED IN PATH CLASS
            Level2Teleport();
            MoveAndRun(ellen, pad1, 1f);
        }
    }
}
