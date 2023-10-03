using ElevatorSimulator.Helpers;
using ElevatorSimulator.Interfaces;
using Moq;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class ValidNumberCheckerTests
    {
        private Mock<IConsoleService> _mockConsoleService;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleService = new Mock<IConsoleService>();
        }

        [Test]
        public void GetValidNumber_ValidInput_ReturnsParsedInteger()
        {
            _mockConsoleService.SetupSequence(s => s.ReadLine())
                               .Returns("5");

            var result = ValidNumberChecker.GetValidNumber("Enter number: ", null, _mockConsoleService.Object);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void GetValidNumber_InputGreaterThanMaxNumber_RePromptsForValidInput()
        {
            _mockConsoleService.SetupSequence(s => s.ReadLine())
                               .Returns("7")
                               .Returns("3");

            var result = ValidNumberChecker.GetValidNumber("Enter number: ", 5, _mockConsoleService.Object);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetValidNumber_InvalidInput_RePromptsForValidInput()
        {
            _mockConsoleService.SetupSequence(s => s.ReadLine())
                               .Returns("invalid")
                               .Returns("3");

            var result = ValidNumberChecker.GetValidNumber("Enter number: ", null, _mockConsoleService.Object);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetValidNumber_EmptyInput_RePromptsForValidInput()
        {
            _mockConsoleService.SetupSequence(s => s.ReadLine())
                               .Returns("")
                               .Returns("3");

            var result = ValidNumberChecker.GetValidNumber("Enter number: ", null, _mockConsoleService.Object);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetValidNumber_ExceptionDuringProcessing_RePromptsForValidInput()
        {
            _mockConsoleService.SetupSequence(s => s.ReadLine())
                   .Throws(new Exception("Test exception"))
                   .Returns("3");

            var result = ValidNumberChecker.GetValidNumber("Enter number: ", null, _mockConsoleService.Object);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
