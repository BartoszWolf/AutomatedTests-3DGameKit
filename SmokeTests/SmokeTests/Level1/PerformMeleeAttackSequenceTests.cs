using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class PerformMeleeAttackSequenceTests : SetupCloseApplication
    {
        [Test]
        public void AttackCheck()
        {
            //CALL METHOD THAT IS STORED IN PATH CLASS
            TeleportToStaff();

            //ROTATE CHARACTER
            api.CallMethod(ellen + componentTransform, "Rotate", new Vector3[] { new Vector3(0f, -180f, 0f) });

            //DECLARATE COUNTER
            int counter = 0;

            //ITERATE 4 TIMES AND INCREASE COUNTER ON EACH
            for (int i = 0; i < 4; i++)
            {
                if(Attacking())
                {
                    counter++;
                }
            }

            //CHECK WHETHER COMBO IS PERFORMED
            bool didCombo = counter == 4 ? true : false;

            //ASSERTIONS TO CHECK IF CONDITIONS ARE MET
            Assert.That(didCombo, Is.True, "Combo wasnt performed as the Player didnt attack 4 times in a row");
        }
    }
}
