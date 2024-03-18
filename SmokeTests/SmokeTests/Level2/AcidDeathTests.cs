using gdio.common.objects;
using NUnit.Framework;
using System;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class AcidDeathTests : SetupDisconnectClient
    {
        [Test]
        public void Acid()
        {
            //CALL METHODS THAT ARE STORED IN PATH CLASS
            Level2Teleport();
            Checkpoint2Teleport("2");

            //REGISTER COLLISION EVENT, WHICH RETURNS A STRING ID
            string id = api.RegisterCollisionMonitor("//*[@name='Acid'][0]");

            //VECTOR3 TO STORE ACID LAKE POSITION
            Vector3 acid = api.GetObjectPosition("//*[@name='Acid'][0]");

            //TELEPORT PLAYER OVER THE ACID LAKE
            api.SetObjectFieldValue(ellenPosition, position, new Vector3(acid.x, acid.y+15, acid.z));

            //WAIT FOR COLLISION OCCUR
            Collision didTouch = api.WaitForCollisionEvent(id);

            //CHECK IF COLLISION WAS DETECTED
            if (didTouch != null)
            {
                Console.WriteLine("Got Event");
            }
            else
            {
                Assert.That(didTouch, Is.True, "Hero died in an acid lake");
            }
        }
    }
}
 
