using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class HighSpeedElevator : IElevator
    {
        // TODO: Extend this to keep track.
        private FloorLevel _currentFloor = FloorLevel.One;

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

        public void OpenDoor()
        {
            // TODO: Implement the logic for opened door.
            Console.WriteLine("HighSpeed Elevator door opened.");
        }

        public void CloseDoor()
        {
            // TODO: Implement the logic for closed door.
            Console.WriteLine("HighSpeed Elevator door closed.");
        }
    }
}
