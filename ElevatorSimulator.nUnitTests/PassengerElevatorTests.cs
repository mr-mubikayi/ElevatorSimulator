using ElevatorSimulator.Classes;
using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;
using Moq;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class PassengerElevatorTests
    {
        private Mock<IConsoleService> _mockConsoleService;
        private PassengerElevator _elevator;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleService = new Mock<IConsoleService>();
            _elevator = new PassengerElevator(_mockConsoleService.Object);
        }

        [Test]
        public void Constructor_InitializesExpectedValues()
        {
            Assert.IsNotNull(_elevator.Id);
            Assert.That(_elevator.CurrentFloor, Is.EqualTo(FloorLevel.One));
            Assert.That(_elevator.Direction, Is.EqualTo(MovementStatus.Stationary));
            Assert.IsFalse(_elevator.IsMoving);
            Assert.IsFalse(_elevator.IsDoorOpened);
            Assert.That(_elevator.PassengerCount, Is.EqualTo(0));
            Assert.That(_elevator.MaxPassengerCount, Is.EqualTo(ElevatorMaxWeights.PassengerElevator));
        }

        [Test]
        public async Task CallElevator_CallsElevatorToSpecifiedFloor()
        {
            await _elevator.CallElevator(FloorLevel.Two);

            Assert.That(_elevator.CurrentFloor, Is.EqualTo(FloorLevel.Two));
        }

        [Test]
        public async Task GoToFloor_MovesElevatorToSpecifiedFloor()
        {
            await _elevator.GoToFloor(FloorLevel.Three);

            Assert.That(_elevator.CurrentFloor, Is.EqualTo(FloorLevel.Three));
        }

        [Test]
        public async Task OpenDoor_ChangesDoorStatusToOpened()
        {
            await _elevator.OpenDoor();

            Assert.IsTrue(_elevator.IsDoorOpened);
        }

        [Test]
        public async Task CloseDoor_ChangesDoorStatusToClosed()
        {
            await _elevator.OpenDoor(); // First, open the door
            await _elevator.CloseDoor(); // Then, close the door

            Assert.IsFalse(_elevator.IsDoorOpened);
        }

        [Test]
        public void AddPassengers_IncreasesPassengerCount()
        {
            _mockConsoleService.Setup(s => s.ReadLine()).Returns("2");
            _elevator.AddPassengers();

            Assert.That(_elevator.PassengerCount, Is.EqualTo(2));
        }

        [Test]
        public void RemovePassengers_DecreasesPassengerCount()
        {
            _mockConsoleService.Setup(s => s.ReadLine()).Returns("2");
            _elevator.AddPassengers();

            _mockConsoleService.Setup(s => s.ReadLine()).Returns("1");
            _elevator.RemovePassengers();

            Assert.That(_elevator.PassengerCount, Is.EqualTo(1));
        }
    }
}
