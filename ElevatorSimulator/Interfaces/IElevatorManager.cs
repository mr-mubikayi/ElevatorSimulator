using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Interfaces
{
    public interface IElevatorManager
    {
        int ElevatorsCount { get; }
        void AddElevator(IElevator elevator);
        IEnumerable<IElevator> GetAllElevators();
        IElevator GetAvailableElevator(FloorLevel currentFloorNumber);
    }
}