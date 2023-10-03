using ElevatorSimulator.Constants;
using System;
namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class DisplayTextsInitializationTests
    {
        [Test]
        public void TestDisplayTextsInitialization_InitializesCorrectly()
        {
            Assert.IsNotNull(DisplayTexts.MAIN_MENU_TEXT);
            Assert.IsNotNull(DisplayTexts.TITLE_TEXT);
            Assert.IsNotNull(DisplayTexts.ENTER_VALUE_TEXT);
        }
    }
}
