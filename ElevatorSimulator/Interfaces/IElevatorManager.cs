namespace ElevatorSimulator.Interfaces
{
    public interface IElevatorManager
    {
        IElevator GetAvailableElevator();
        void AddElevator(IElevator elevator);
        int Count { get; }
        IEnumerable<IElevator> GetAllElevators(); // New method
    }
}