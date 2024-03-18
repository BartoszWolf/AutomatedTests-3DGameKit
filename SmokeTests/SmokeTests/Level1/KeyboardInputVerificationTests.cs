using gdio.common.objects;
using NUnit.Framework;

namespace SmokeTests.Smokes
{
    [TestFixture]
    public class KeyboardInputVerificationTests : SetupCloseApplication
    {
        //TESTCASES WITH PASSED PARAMETERS
        [TestCase("ForwardBefore", "ForwardAfter", 1f, "Vertical", "Forward")]
        [TestCase("BackwardBefore", "BackwardAfter", -1f, "Vertical", "Backward")]
        [TestCase("RightBefore", "RightAfter", 1f, "Horizontal", "Right")]
        [TestCase("LeftBefore", "LeftAfter", -1f, "Horizontal", "Left")]

        [Test]
        //DECLARATION OF ARGUMENTS SETTED IN TESTCASES
        public void InputCheck(string ssLocationBefore, string ssLocationAfter, float inputValue, string axis, string direction)
        {
            //CALL THE METHOD
            InputChecker(ssLocationBefore, ssLocationAfter, inputValue, axis , direction);
        }

        public void InputChecker(string ssLocationBefore,string ssLocationAfter, float inputValue, string axis, string direction)
        {

            //STORE CHARACTER INITIAL POSITION
            Vector3 initPosition = api.GetObjectPosition(ellen);

            //SCREENSHOT TAKEN BEFORE MOVE
            api.CaptureScreenshot(Screenshot(ssLocationBefore), false, true);

            //MOVE CHARACTER IN DESIRED DIRECTION
            api.AxisPress(axis, inputValue, (ulong)api.GetLastFPS() * 3);

            //SCREENSHOT TAKEN AFTER MOVE
            api.Wait(2000);
            api.CaptureScreenshot(Screenshot(ssLocationAfter), false, true);

            //STORE CHARACTER NEW POSITION
            Vector3 resuPosition = api.GetObjectPosition(ellen);

            //VALIDATE IF INITIAL POSITION AND NEW POSITION ARE DIFFERENT
            Assert.That(resuPosition != initPosition, $"Character didnt move in {direction} direction, something is wrong with input.");
        }
    }
}
