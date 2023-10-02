using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Helpers;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class PassengerElevator : IElevator
    {
        private readonly Guid _id;
        private bool _isDoorOpened;
        private string _subStringGuid;
        private FloorLevel _currentFloor;
        private MovementStatus _direction;

        public Guid Id => _id;
        public FloorLevel CurrentFloor => _currentFloor;
        public MovementStatus Direction => _direction;
        public bool IsMoving => _direction != MovementStatus.Stationary;
        public bool IsDoorOpened => _isDoorOpened;
        public int PassengerCount { get; private set; }
        public int MaxPassengerCount => ElevatorMaxWeights.PassengerElevator;

        public PassengerElevator()
        {
            _id = Guid.NewGuid();
            _isDoorOpened = false;
            _subStringGuid = _id.ToString().Split('-')[0];
            _currentFloor = FloorLevel.One;
            _direction = MovementStatus.Stationary;
        }

        public async Task CallElevator(FloorLevel currentFloorLevel)
        {
            Console.WriteLine($"\nCalling elevator {_subStringGuid}...");

            _direction = _currentFloor == currentFloorLevel
                ? MovementStatus.Stationary
                : (_currentFloor < currentFloorLevel ? MovementStatus.Up : MovementStatus.Down);

            Console.WriteLine(_direction == MovementStatus.Stationary
                ? $"Elevator {_subStringGuid} already at floor: {_currentFloor}"
                : $"Elevator {_subStringGuid} moving from floor {_currentFloor} to {currentFloorLevel}...");

            await OperationDelays.PassengerElevator(null);

            if (_direction != MovementStatus.Stationary)
            {
                _currentFloor = currentFloorLevel;
                _direction = MovementStatus.Stationary;

                Console.WriteLine($"Elevator {_subStringGuid} arrived at floor: {_currentFloor}");
            }

            await OpenDoor();

            if (PassengerCount > 0)
                RemovePassengers();

            AddPassengers();

            await CloseDoor();
        }

        public async Task GoToFloor(FloorLevel desiredFloorLevel)
        {
            _direction = _currentFloor == desiredFloorLevel
                ? MovementStatus.Stationary
                : (_currentFloor < desiredFloorLevel ? MovementStatus.Up : MovementStatus.Down);

            Console.WriteLine(_direction == MovementStatus.Stationary
                ? $"Elevator {_subStringGuid} already at floor: {_currentFloor}"
                : $"Elevator {_subStringGuid} moving from floor {_currentFloor} to {desiredFloorLevel}...");

            await OperationDelays.PassengerElevator(null);

            if (_direction != MovementStatus.Stationary)
            {
                _currentFloor = desiredFloorLevel;
                _direction = MovementStatus.Stationary;

                Console.WriteLine($"Elevator {_subStringGuid} arrived at floor: {_currentFloor}");
            }

            await OpenDoor();

            if (PassengerCount > 0)
                RemovePassengers();
        }

        public async Task OpenDoor()
        {
            Console.WriteLine("Opening door...");

            await OperationDelays.PassengerElevator(null);

            _isDoorOpened = true;

            Console.WriteLine("Door Opened.");
        }

        public async Task CloseDoor()
        {
            Console.WriteLine("Closing door...");

            await OperationDelays.PassengerElevator(null);

            _isDoorOpened = false; 

            Console.WriteLine("Door Closed.");
        }

        public void AddPassengers()
        {
            var maxToBeEntered = MaxPassengerCount - PassengerCount;
            var passengerExitText = $"\nElevator {_subStringGuid} has {PassengerCount} passengers " +
                                    $"\nHow many are entering? ({maxToBeEntered} max): ";

            var passengerCount = ValidNumberChecker.GetValidNumber(passengerExitText, maxToBeEntered);

            PassengerCount += passengerCount;
            Console.WriteLine($"{passengerCount} passengers entered. Current count: {PassengerCount}");
        }

        public void RemovePassengers()
        {
            var passengerExitText = $"\nElevator {_subStringGuid} has {PassengerCount} passengers " +
                                    $"\nHow many are exiting?: ";

            var passengerCount = ValidNumberChecker.GetValidNumber(passengerExitText, PassengerCount);

            PassengerCount = Math.Max(PassengerCount - passengerCount, 0);
            Console.WriteLine($"{passengerCount} passengers exited. Current count: {PassengerCount}");
        }
    }
}
