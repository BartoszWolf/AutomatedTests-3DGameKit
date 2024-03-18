using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class CameraMovementVerification : SetupCloseApplication
    {
        //TESTCASESOURCE WITH PASSED ARRAY OF OBJECTS WITH PARAMETERS
        [Test, TestCaseSource(nameof(Inputs))]
        public void CameraCheck(string ssLocationBefore, string ssLocationAfter, string cameraAxis, float inputValue, string direction)
        {
            CameraChecker(ssLocationBefore, ssLocationAfter, cameraAxis, inputValue, direction);
        }
        
        //PARAMETERS STORED AS ARRAY OF OBJECTS
        public static object[] Inputs =
        {
            new object[] { "UpBefore", "UpAfter", "CameraY", -1f, "Up" },
            new object[] { "DownBefore", "DownAfter", "CameraY", 1f, "Down" },
            new object[] { "RightBefore", "RightAfter", "CameraX", 1f, "Right" },
            new object[] { "LeftBefore", "LeftAfter", "CameraX", -1f, "Left" }
    
        };

        //METHOD VALIDATING IF CAMERA IS MOVING CORRECTLY
        public void CameraChecker(string ssLocationBefore, string ssLocationAfter, string cameraAxis, float inputValue, string direction)
        {
            //WAIT FOR CAMERA
            api.WaitForObject(mainCamera);

            //VECTOR3 CONTAINS CAMERA POSITION BEFORE MOVE
            Vector3 cameraPosition = api.GetObjectPosition(mainCamera);

            //SCREENSHOT TAKEN BEFORE MOVE
            api.CaptureScreenshot(Screenshot(ssLocationBefore), false, true);

            //MOVE CAMERA IN DESIRED DIRECTION
            api.AxisPress(cameraAxis, inputValue, (ulong)api.GetLastFPS()/ 3);

            //SCREENSHOT TAKEN AFTER MOVE
            api.Wait(2000);
            api.CaptureScreenshot(Screenshot(ssLocationAfter), false, true);

            //VECTOR3 CONTAINS CAMERA POSITION AFTER MOVE
            Vector3 newPosition = api.GetObjectPosition(mainCamera);

            //VALIDATE WHETHER CAMERA MOVED
            Assert.That(cameraPosition != newPosition, $"Camera didn't move in {direction} direction.");
        }
    }
}
