using ElevatorSimulator.Constants;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class DisplayTextsTests
    {
        [Test]
        public void MAIN_MENU_TEXT_IsCorrect()
        {
            string expected = @"
.__________ Main Menu __________.
|                               |
|   1. Call Elevator            |
|   2. Display Elevator Status  |
|   3. Exit                     | 
|_______________________________|

Choose an Option (1, 2, 3): ";
            Assert.That(DisplayTexts.MAIN_MENU_TEXT, Is.EqualTo(expected));
        }

        [Test]
        public void TITLE_TEXT_IsCorrect()
        {
            Assert.That(DisplayTexts.TITLE_TEXT, Is.EqualTo("\n       ELEVATOR SIMULATOR"));
        }

        // TODO: Add tests for other constants as well

        [Test]
        public void ERROR_OCCURED_IsCorrect()
        {
            Assert.That(DisplayTexts.ERROR_OCCURED, Is.EqualTo("An unexpected error occurred: {0}"));
        }

        // TODO: Continue in this manner for other constants
    }
}
