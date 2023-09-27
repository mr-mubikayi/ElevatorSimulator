using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class PassengerElevator : IElevator
    {
        private bool _isDoorOpened = false;
        private FloorLevel _currentFloor = FloorLevel.One;
        private MovementStatus _direction = MovementStatus.Stationary;  

        public FloorLevel CurrentFloor => _currentFloor;
        public MovementStatus Direction => _direction;
        public bool IsMoving => _direction != MovementStatus.Stationary;
        public bool IsDoorOpened => _isDoorOpened;
        public int PassengerCount { get; private set; }
        public int MaxPassengerCount => Constants.Constants.MaxPassengerElevatorCount;


        public async void GoToFloor(FloorLevel floorLevel)
        {
            _direction = 
                _currentFloor == floorLevel 
                ? MovementStatus.Stationary
                : _currentFloor < floorLevel 
                ? MovementStatus.MovingUp 
                : MovementStatus.MovingDown;

            if(_direction == MovementStatus.Stationary)
            {
                _currentFloor = floorLevel;
                return;
            }

            Console.WriteLine($"Elevator moving from floor {_currentFloor} to {floorLevel}");

            await Task.Delay(Math.Abs(floorLevel - _currentFloor) * 1000);

            _currentFloor = floorLevel;
            _direction = MovementStatus.Stationary;

            Console.WriteLine($"Elevator arrived at floor: {_currentFloor}");
        }

        public void AddPassengers(int count)
        {
            if (PassengerCount + count <= MaxPassengerCount)
            {
                PassengerCount += count;
                Console.WriteLine($"{count} passengers entered. Current count: {PassengerCount}");
            }
            else
            {
                Console.WriteLine($"Overload Alert! Can't add {count} passengers.");
            }
        }

        public void RemovePassengers(int count)
        {
            PassengerCount = Math.Max(PassengerCount - count, 0);
            Console.WriteLine($"{count} passengers exited. Current count: {PassengerCount}");
        }

        public async void OpenDoor()
        {
            Console.WriteLine("Opening door...");

            await Task.Delay(2000);

            _isDoorOpened = true;

            Console.WriteLine("Door Opened");
        }

        public async void CloseDoor()
        {
            Console.WriteLine("Closing door...");

            await Task.Delay(2000);

            _isDoorOpened = false;

            Console.WriteLine("Door Closed");
        }

        //// TODO: Extend this to keep track.
        //private FloorLevel _currentFloor = FloorLevel.One;

        //public void GoToFloor(FloorLevel floorLevel)
        //{
        //    // TODO: Implement the logic to move the elevator to the specified floor.
        //    _currentFloor = floorLevel;
        //    Console.WriteLine($"Passenger Elevator going to floor: {_currentFloor}");
        //}

        //public void Direction()
        //{
        //    // TODO: Implement the logic to decide the direction (up/down) based on current and destination floors.
        //    Console.WriteLine("Passenger Elevator direction is set.");
        //}

        //public void OpenDoor()
        //{
        //    // TODO: Implement the logic for opened door.
        //    Console.WriteLine("Passenger Elevator door opened.");
        //}

        //public void CloseDoor()
        //{
        //    // TODO: Implement the logic for closed door.
        //    Console.WriteLine("Passenger Elevator door closed.");
        //}
    }
}
