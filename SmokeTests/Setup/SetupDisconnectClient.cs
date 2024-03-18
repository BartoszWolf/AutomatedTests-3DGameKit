using gdio.common.objects;
using gdio.unity_api.v2;
using NUnit.Framework;

namespace SmokeTests
{
    public class SetupDisconnectClient : Paths
    {
        [SetUp]
        public void Connect()
        {
            //INITIALIZED API AND CONNECTED WITH GAME
            api = new ApiClient();
            api.Connect("localhost", 19734, true, 30, false);

            //HOOK INPUT
            api.EnableHooks(HookingObject.ALL);

            //START THE GAME
            api.WaitForObject("//*[@name='StartButton']");
            api.ClickObject(MouseButtons.LEFT, "//*[@name='StartButton']", 30);

            //WAIT FOR LOAD
            api.WaitForObject("//*[@name='Ellen']");
            api.Wait(5000);
        }

        [TearDown]
        public void TearDown()
        {
            //DISABLE HOOK INPUT
            api.DisableHooks(HookingObject.ALL);

            //DISCONNECT API
            api.Disconnect();
        }
    }
}
