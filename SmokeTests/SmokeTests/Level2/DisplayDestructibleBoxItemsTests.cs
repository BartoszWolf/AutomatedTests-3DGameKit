using NUnit.Framework;
using System;

namespace SmokeTests.Smokes.Level2
{
    [TestFixture]
    public class DisplayDestructibleBoxItemsTests : SetupCloseApplication
    {
        [Test]
        public void GetObjectList()
        {
            //STORE OBJECTLIST OF DESTRUCTIBLE BOXED
            var objectList = api.GetObjectList("(//*[@name='DestructibleBox'])", true, 60);

            //CHECK WHETHER LIST IN NOT EMPTY
            Assert.That(objectList, Is.Not.Null, "Is not empty");

            //DISPLAY OBJECTS NAME IN THE CONSOLE
            foreach(var item in objectList)
            {
                Console.WriteLine(item.name.ToString());
            }
        }
    }
}
