using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class GrenadiersKillTests : SetupDisconnectClient
    {
        [Test]
        public void KillTheBoss()
        {
            //CALL THE METHOD
            Level2Teleport();
            Checkpoint2Teleport("7");

            //TURN THE SHIELD ON
            api.CallMethod("//*[@name='Ellen_Shield']", "SetActive", new object[] { true });

            //INT TO STORE GRENADIER HIT POINTS
            int grenadierHP = api.GetObjectFieldValue<int>("//*[@name='DamageablePart']/fn:component('Gamekit3D.Damageable')/@currentHitPoints");

            //INT TO STORE PLAYER HIT POINTS
            int playerHP = api.GetObjectFieldValue<int>("//*[@name='Ellen']/fn:component('Gamekit3D.Damageable')/@currentHitPoints");

            //SET PLAYER ATTACK VALUE TO 10
            SetAttack(10);

            //LOGIC FOR LOCATION AND ATTACKING GRENADIER UNTIL HIS DEATH
            for(int i = 0; i<=1; )
            {
                //GET AND CHANGE GRENADIER POSITION TO TELEPORT THE PLAYER
                Vector3 Grenadier = api.GetObjectFieldValue<Vector3>($"//*[@name='Grenadier'][{i}]/fn:component('UnityEngine.Transform')/@position");
                Grenadier.x -= 2; Grenadier.z -= 1;

                //STORE GRENADIER POSITION TO USE LOOK AT METHOD
                Vector3 GrenadireLook = api.GetObjectFieldValue<Vector3>($"//*[@name='Grenadier'][{i}]/fn:component('UnityEngine.Transform')/@position");

                //SET CHARACTER POSITION
                api.SetObjectFieldValue(ellenPosition, "position", Grenadier);

                //ROTATE CHARACTER TOWARD GRENADIER POSITION
                api.CallMethod(ellen + componentTransform, lookAt, new Vector3[] { GrenadireLook });

                //ATTACK 4 TIMES
                for (int j = 0; j < 4; j++)
                {
                    Attacking();
                }

                //IF THE PLAYERS HEALTH GET BELOW 5, SET IT BACK TO 5
                playerHP = api.GetObjectFieldValue<int>("//*[@name='Ellen']/fn:component('Gamekit3D.Damageable')/@currentHitPoints");
                if (playerHP != 5)
                {
                    api.CallMethod(ellenDamagable, "set_currentHitPoints", new object[] { 5 });
                }

                //IF GRENADIER IS KILLED, ITERATE TO CONETRACTE ON THE SECOND ONE
                grenadierHP = api.GetObjectFieldValue<int>($"//*[@name='DamageablePart'][{i}]/fn:component('Gamekit3D.Damageable')/@currentHitPoints");
                if(grenadierHP <= 0)
                {
                    i++;
                }
            }
        }

    }
}
