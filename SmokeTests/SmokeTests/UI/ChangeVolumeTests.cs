using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;

namespace SmokeTests.Smokes.UI
{
    [TestFixture, Order(3)]
    public class ChangeVolumeTests : SetupCloseApplication
    {
        [Test]
        public void ChangingVolume()
        {
            //SET MASTER VOLUME TO 0
            api.Wait(2000);
            Single minVal = api.GetObjectFieldValue<Single>("//*[@name='MasterVolumeSlider']/fn:component('UnityEngine.UI.Slider')/@minValue");
            api.SetObjectFieldValue("//*[@name='MasterVolumeSlider']/fn:component('UnityEngine.UI.Slider')", "value", minVal);

            //CHECK IF THE MASTER VOLUME VALUE HAS CHANGED
            Single currentVal = api.GetObjectFieldValue<Single>("//*[@name='MasterVolumeSlider']/fn:component('UnityEngine.UI.Slider')/@value");
            ClassicAssert.AreEqual(minVal, minVal, "Volume hasn't changed");


            //CHANGE MUSIC VOLUME TO 50%
            Single halfOfCurrentMusic = api.GetObjectFieldValue<Single>("//*[@name='MusicVolumeSlider']/fn:component('UnityEngine.UI.Slider')/@value");
            api.SetObjectFieldValue("//*[@name='MusicVolumeSlider']/fn:component('UnityEngine.UI.Slider')", "value", halfOfCurrentMusic / 2);

            //CHECK IF THE MASTER VOLUME VALUE HAS BEEN CHANGED CORRECTLY
            Single currentMusicVal = api.GetObjectFieldValue<Single>("//*[@name='MusicVolumeSlider']/fn:component('UnityEngine.UI.Slider')/@value");
            ClassicAssert.AreEqual(halfOfCurrentMusic, currentMusicVal * 2, "Music Volume hasn't changed");

            //SET VOLUME SLIDER TO MAX USING A METHOD
            Single maxValSFX = api.GetObjectFieldValue<Single>("//*[@name='SFXVolumeSlider']/fn:component('UnityEngine.UI.Slider')/@maxValue");
            api.CallMethod("//*[@name='SFXVolumeSlider']/fn:component('UnityEngine.UI.Slider')", "set_value", new object[] { maxValSFX });

            //CHECK IF THE VOLUME SLIDER HAS BEEN CHANGED TO MAXIMUM
            Single currentSFXVal = api.GetObjectFieldValue<Single>("//*[@name='SFXVolumeSlider']/fn:component('UnityEngine.UI.Slider')/@value");
            ClassicAssert.AreEqual(maxValSFX, currentSFXVal, "SFX volume hasn't chagned");
        }
    }
}
