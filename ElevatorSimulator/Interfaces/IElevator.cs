using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Interfaces
{
    public interface IElevator
    {
        FloorLevel CurrentFloor { get; }
        MovementStatus Direction { get; }

        bool IsMoving { get; }
        bool IsDoorOpened { get; }

        int PassengerCount { get; }
        int MaxPassengerCount { get; }

        void GoToFloor(FloorLevel floorLevel);
        void AddPassengers(int count);
        void RemovePassengers(int count);
        void OpenDoor();
        void CloseDoor();
    }
}