using ElevatorSimulator.Classes;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;
using Moq;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class ElevatorFactoryTests
    {
        private Mock<IConsoleService> _mockConsoleService;
        private ElevatorFactory _elevatorFactory;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleService = new Mock<IConsoleService>();
            _elevatorFactory = new ElevatorFactory(_mockConsoleService.Object);
        }

        [Test]
        public void GetElevator_WithValidType_ReturnsElevatorInstance()
        {
            var elevator = _elevatorFactory.GetElevator(ElevatorType.Passenger, FloorLevel.One);

            Assert.IsNotNull(elevator);
            Assert.IsAssignableFrom<IElevator>(elevator);
        }

        [Test]
        public void GetElevator_WithInvalidType_ReturnsNullAndWritesToConsole()
        {
            var invalidType = (ElevatorType)999;

            var elevator = _elevatorFactory.GetElevator(invalidType, FloorLevel.One);

            Assert.IsNull(elevator);
            _mockConsoleService.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddElevators_AddingNewElevators_IncreasesCount()
        {
            _elevatorFactory.AddElevators(ElevatorType.Passenger, 5);

            var elevators = _elevatorFactory.GetAllElevatorsByType(ElevatorType.Passenger);
            Assert.That(elevators.Count(), Is.EqualTo(5));
        }

        [Test]
        public void GetAllElevatorsByType_WithValidType_ReturnsCollectionOfElevators()
        {
            _elevatorFactory.AddElevators(ElevatorType.Passenger, 3);

            var elevators = _elevatorFactory.GetAllElevatorsByType(ElevatorType.Passenger);

            Assert.That(elevators.Count(), Is.EqualTo(3));
        }

        [Test]
        public void GetAllElevatorsByType_WithInvalidType_ReturnsEmptyCollectionAndWritesToConsole()
        {
            var invalidType = (ElevatorType)999;

            var elevators = _elevatorFactory.GetAllElevatorsByType(invalidType);

            Assert.That(elevators.Count(), Is.EqualTo(0));
            _mockConsoleService.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}
