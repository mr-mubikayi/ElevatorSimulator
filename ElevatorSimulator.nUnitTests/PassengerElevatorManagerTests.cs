using ElevatorSimulator.Classes;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;
using Moq;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class PassengerElevatorManagerTests
    {
        private Mock<IConsoleService> _mockConsoleService;
        private PassengerElevatorManager _manager;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleService = new Mock<IConsoleService>();
            _manager = new PassengerElevatorManager(_mockConsoleService.Object);
        }

        [Test]
        public void AddElevator_WhenCalled_IncreasesElevatorCount()
        {
            var elevator = new Mock<IElevator>().Object;
            _manager.AddElevator(elevator);

            Assert.That(_manager.ElevatorsCount, Is.EqualTo(1));
        }

        [Test]
        public void GetAvailableElevator_WithStationaryElevatorOnSameFloor_ReturnsThatElevator()
        {
            var elevator = new Mock<IElevator>();
            elevator.Setup(e => e.CurrentFloor).Returns(FloorLevel.One);
            elevator.Setup(e => e.Direction).Returns(MovementStatus.Stationary);
            _manager.AddElevator(elevator.Object);

            var result = _manager.GetAvailableElevator(FloorLevel.One);

            Assert.That(result, Is.EqualTo(elevator.Object));
        }

        [Test]
        public void GetAvailableElevator_WithElevatorMovingTowards_ReturnsThatElevator()
        {
            var elevator = new Mock<IElevator>();
            elevator.Setup(e => e.CurrentFloor).Returns(FloorLevel.Two);
            elevator.Setup(e => e.Direction).Returns(MovementStatus.Down);
            _manager.AddElevator(elevator.Object);

            var result = _manager.GetAvailableElevator(FloorLevel.One);

            Assert.That(result, Is.EqualTo(elevator.Object));
        }

        [Test]
        public void GetAvailableElevator_WithStationaryElevatorOnDifferentFloor_ReturnsThatElevator()
        {
            var elevator = new Mock<IElevator>();
            elevator.Setup(e => e.CurrentFloor).Returns(FloorLevel.Three);
            elevator.Setup(e => e.Direction).Returns(MovementStatus.Stationary);
            _manager.AddElevator(elevator.Object);

            var result = _manager.GetAvailableElevator(FloorLevel.One);

            Assert.That(result, Is.EqualTo(elevator.Object));
        }

        [Test]
        public void GetAllElevators_WhenCalled_ReturnsAllElevators()
        {
            var elevator1 = new Mock<IElevator>().Object;
            var elevator2 = new Mock<IElevator>().Object;
            _manager.AddElevator(elevator1);
            _manager.AddElevator(elevator2);

            var result = _manager.GetAllElevators().ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.Contains(elevator1, result);
            Assert.Contains(elevator2, result);
        }
    }
}
