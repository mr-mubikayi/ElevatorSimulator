using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class HighSpeedElevator : IElevator
    {
        // TODO: Extend this to keep track.
        private bool _isDoorOpened = false;
        private FloorLevel _currentFloor = FloorLevel.One;

        public FloorLevel CurrentFloor => throw new NotImplementedException();

        MovementStatus IElevator.Direction => throw new NotImplementedException();

        public bool IsMoving => throw new NotImplementedException();

        public int PassengerCount => throw new NotImplementedException();

        public int MaxPassengerCount => throw new NotImplementedException();

        public bool IsDoorOpened => _isDoorOpened;

        public void GoToFloor(FloorLevel floorLevel)
        {
            // TODO: Implement the logic to move the elevator to the specified floor.
            _currentFloor = floorLevel;
            Console.WriteLine($"HighSpeed Elevator going to floor: {_currentFloor}");
        }

        public void Direction()
        {
            // TODO: Implement the logic to decide the direction (up/down) based on current and destination floors.
            Console.WriteLine("HighSpeed Elevator direction is set.");
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

        public void AddPassengers(int count)
        {
            throw new NotImplementedException();
        }

        public void RemovePassengers(int count)
        {
            throw new NotImplementedException();
        }
    }
}
