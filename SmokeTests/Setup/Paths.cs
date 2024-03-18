using gdio.common.objects;
using gdio.unity_api.v2;
using NUnit.Framework;

namespace SmokeTests
{
    //PURPOSE OF THIS CLASS IS TO CONTAIN PATHS TO THE MOST COMMONLY USED OBJECTS WITHIN THE GAME AND KEEP SELF-CREATED METHODS\\
    public class Paths
    {
                                                //API CLIENT OBJECT DECLARATION\\
        public ApiClient api;

                    //___________________________________________________________________________________\\
                    //_______________________________________XPATH_______________________________________\\
                    //___________________________________________________________________________________\\

                                                         //CHARACTER\\
        public string ellen = "//*[@name='Ellen']";
        public string ellenPosition = "//*[@name='Ellen']/fn:component('UnityEngine.Transform')";
        public string ellenDamagable = "//*[@name='Ellen']/fn:component('Gamekit3D.Damageable')";
        public string playerInputAttack = "//*[@name='Ellen']/fn:component('PlayerInput')/@Attack";
        public string playerHP = "//*[@name='Ellen']/fn:component('Gamekit3D.Damageable')/@currentHitPoints";

                                                           //WEAPON\\
        public string staff1A = "(//*[@name='Staff'])[1]/@active";
        public string staff = "(//*[@name='Staff'])[1]";
        public string staffInInventory = "//*[@name='Staff']";
        public string componentTransform = "/fn:component('UnityEngine.Transform')";
        public string staffPosition = "(//*[@name='Staff'])[1]/fn:component('UnityEngine.Transform')/@position";

    
                                                           //ENEMIES\\
        public string chomper = "(//*[@name='Chomper'])";
        public string chomperBehavior = "fn:component('Gamekit3D.ChomperBehavior')";
        public string chomperActive = "//*[@name='Chomper']/@active";
        public string grenadierBehavior = "//*[@name='Grenadier']/fn:component('Gamekit3D.GrenadierBehaviour')";


                                                           //GENERAL\\
        public string mainCamera = "//MainCamera[@name='CameraBrain']";
        public string hashAttack = "hashAttack";
        public string hashHit = "hashHit";
        public string active = "active";
        public string rotation = "Rotate";
        public string position = "position";
        public string lookAt = "LookAt";
        public string getActive = "get_active";
        public string fire = "Fire1";
        public string doorHugePosition = "//*[@name='DoorHuge1']/fn:component('Gamekit3D.GameCommands.SimpleTranslator')";
        public string pad1 = "//*[@name='PressurePad1']";

                       //___________________________________________________________________________________\\
                       //______________________________________METHIDS______________________________________\\
                       //___________________________________________________________________________________\\

        //METHOD THAT TAKES AS PARAMTERS NAME OF SCREENSHOT THAT WILL BE PLACED IN DESIRED DESTINATION
        public string Screenshot(string ssName)
        {
            string name = $"C:\\Users\\barte\\OneDrive\\Pulpit\\Unity\\3D Practise\\SmokeTests\\Screenshots\\{ssName}.png";
            return name;
        }

        //METHOD THAT RETURNS VECTOR3 AND PARAMETER CAN BE SET AS API.GETOBJECTFIELD<VECTOR3> FUNCTION
        public Vector3 ReturnVector3(Vector3 vector)
        {
            return vector;
        }

        //METHOD THAT ALLOWS TELEPORT TO THE STAFF THAT IS PLACED IN LEVEL1
        public void TeleportToStaff()
        {
            Vector3 staffLocation = api.GetObjectFieldValue<Vector3>(staffPosition);
            api.SetObjectFieldValue(ellen + componentTransform, position, staffLocation);
            api.Wait(1000);
        }

        //METHOD THAT ALLOWS TO DISARM ALL CHOMPER ENEMIES IN LEVEL1
        public void DisarmEnemies()
        {
            //LOOP TO ITERATE THROUGH ALL THE CHOMPERS
            for (int i = 0; i <= 25; i++)
            {
                //SET HASHATTACK AND BODYDAMAGER OF CHOMPERS TO 0
                api.SetObjectFieldValue(chomper + $"[{i}]/" + chomperBehavior, hashAttack, 0);
                api.SetObjectFieldValue($"(//*[@name='BodyDamager'])[{i}]/fn:component('Gamekit3D.ContactDamager')", "amount", 0);

                //CHECK WHETHER HASHATTACK VALUE HAS BEEN CORRECTLY CHANGED TO 0
                Warn.If(api.GetObjectFieldValue<int>(chomper + $"[{i}]/" + chomperBehavior + "/@" + hashAttack) != 0, $"Chomper{i} attack value hasnt changed correctly to 0");
            }
        }

        //METHOD THAT PERFORM SINGLE ATTACK, NOTICE THAT IT RETURN BOOL SO CAN BE USED TO CHECK WHETHER ATTACKS CAN BE PERFORMED
        public bool Attacking()
        {
            if (api.ButtonPress(fire, (ulong)api.GetLastFPS(), 30))
            {
                api.Wait(300);
                return true;
            }
            else
                return false;
        }

        //METHOD THAT TELEPORT DIRECTLY TO LEVEL2
        public void Level2Teleport()
        {
            api.LoadScene("LeveL2");
            api.Wait(3000);
        }

        //METHOD THAT ACTIVATE STAFF IN THE PLAYER INVENTORY SO THEY CAN PERFORM ATTACKS
        public void WeaponActive()
        {
            api.CallMethod("//*[@name='Ellen']/fn:component('Gamekit3D.PlayerController')", "SetCanAttack", new object[] { true });
            bool canAttack = api.GetObjectFieldValue<bool>("//*[@name='Ellen']/fn:component('Gamekit3D.PlayerController')", "canAttack");
            Assert.That(canAttack, Is.True, "Weapon isnt active on the Player");
        }

        //METHOD THAT TAKES PARAMETERS FOR: PLAYER, DESIREDLOCATION AND INPUT, IT ALLOWS TO RUN TOWARD SPECIFIC OBJECT WITHIN THE SCENE UNTIL REACH IT CLOSELY
        public void MoveAndRun(string ellen, string desiredObject, float input)
        {
            //CALCULATE DISTANCE BETWEEN PLAYER AND OBJECT
            float dist = api.GetObjectDistance(ellen, desiredObject);

            //VECTOR3 THAT CONTAINS OBJECT POSITION
            Vector3 objectdPos = api.GetObjectPosition(desiredObject);

            //ROTATE PLAYER INTO OBJECT'S DIRECTION
            api.CallMethod(ellen + componentTransform, lookAt, new Vector3[] { objectdPos });

            //RUN UNTIL REACH DESIRED OBJECT
            while (dist >= 1)
            {
                api.AxisPress("Vertical", input, (ulong)api.GetLastFPS());
                api.Wait(400);

                dist = api.GetObjectDistance(ellen, desiredObject);
            }

            //CHECK WHETHER THE PLAYER'S POSITION ARE CORRECT
            Assert.That(dist, Is.LessThan(1), "The Player didn't reach desired position");
        }

        //METHOD THAT TAKES PARAMETR OF NUMBER IN STRING CONFIGURED TO TELEPORT PLAYER TO SPECIFIC CHECKPOINT IN LEVEL2 
        public void Checkpoint2Teleport(string number)
        {
            api.SetObjectFieldValue(ellenPosition, position, api.GetObjectPosition($"//*[@name='Checkpoint{number}']"));
            api.Wait(2000);
        }

        //SET ATTACK DAMAGE VALUE OF THE PLAYER
        public void SetAttack(int value)
        {
            int damage = api.GetObjectFieldValue<int>("//*[@name='Staff']/fn:component('Gamekit3D.MeleeWeapon')/@damage");
            api.SetObjectFieldValue("//*[@name='Staff']/fn:component('Gamekit3D.MeleeWeapon')", "damage", value);
            damage = api.GetObjectFieldValue<int>("//*[@name='Staff']/fn:component('Gamekit3D.MeleeWeapon')/@damage");
        }

    }
}

