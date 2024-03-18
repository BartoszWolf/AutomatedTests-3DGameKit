using gdio.common.objects;
using NUnit.Framework;
using System;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class KillChompersTests : SetupCloseApplication
    {
        [Test]
        public void KillChompersTest()
        {
            //CALL METHOD THAT IS STORED IN PATH CLASS
            TeleportToStaff();

            //STORE INITIAL HIT POINTS OF THE CHARACTER
            int fullHP = api.GetObjectFieldValue<int>(playerHP);

            //INITIALIZE BOOL TO CHECK IF ENEMY CHOMPER IS ACTIVE
            bool nextChomper = api.GetObjectFieldValue<bool>(chomperActive);

            //CALL METHOD THAT IS STORED IN PATH CLASS
            DisarmEnemies();

            try
            {
                //WHILE THERE IS STILL AN ACTIVE CHOMPER IN THE SCENE
                while (api.WaitForObject(chomper) != false)
                {
                    //OVERWRITE NEXTCHOMPER VARIABLE
                    nextChomper = api.GetObjectFieldValue<bool>(chomperActive);

                    //KILL THE CHOMPER
                    if (nextChomper)
                    {
                        AttackLogic();
                        api.Wait(500);
                    }
                }
            }
            catch(Exception e)
            {
                //RETURN EXCEPTION MESSAGE
                Console.WriteLine(e.Message);
            }

            //STORE PLAYER'S HIT POINTS VALUE AFTER KILLING ALL THE ENEMIES
            int currentHP = api.GetObjectFieldValue<int>(playerHP);

            //CALL MULTIPLE ASSERTIONS THAT CAN BE RUN SIMULTANEOUSLY
            AssertionPerform(nextChomper, fullHP, currentHP);
           
        }

        //METHOD INDICATING CHOMPERS' POSITION, TELEPORTING CLOSE TO THEM, ROTATING IN THEIR DIRECTION, AND CALLING FOR ATTACK METHOD
        public void AttackLogic()
        {
            Vector3 chomperPos = api.GetObjectPosition(chomper);
            Vector3 chomperLoc = api.GetObjectPosition(chomper);
            api.SetObjectFieldValue(ellen + componentTransform, position, new Vector3(chomperPos.x - 1f, chomperPos.y, chomperPos.z - 1f));
            api.CallMethod(ellen + componentTransform, lookAt, new Vector3[] { chomperLoc });
            Attacking();
        }

        public void AssertionPerform(bool nextChomper, int fullHP, int currentHP)
        {
            //MULTIPLE ASSERTIONS TO VALIDATE TEST OUTCOMES
            Assert.Multiple(() =>
            {
                //CHECK WHETHER THERE ARE MORE CHOMPERS
                Assert.That(nextChomper, Is.False, "There are still more chompers active.");

                //CHECK WHETHER PLAYER WAS HITTED
                Assert.That(fullHP, Is.Not.EqualTo(currentHP), "The Player was hitted during the test performance.");
            });
        }
    }
}
