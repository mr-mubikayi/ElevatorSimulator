using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Interfaces
{
    public interface IElevator
    {
        public void GoToFloor(FloorLevel floorLevel);
        public void Direction();
        public void OpenDoor();
        public void CloseDoor();
    }
}