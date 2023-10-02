using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Interfaces
{
    public interface IElevator
    {
        Guid Id { get; }

        FloorLevel CurrentFloor { get; }
        MovementStatus Direction { get; }

        bool IsMoving { get; }
        bool IsDoorOpened { get; }

        int PassengerCount { get; }
        int MaxPassengerCount { get; }

        Task CallElevator(FloorLevel currentFloorLevel);
        Task GoToFloor(FloorLevel desiredFloorLevel);
        Task OpenDoor();
        Task CloseDoor();

        void AddPassengers();
        void RemovePassengers();
        
    }
}