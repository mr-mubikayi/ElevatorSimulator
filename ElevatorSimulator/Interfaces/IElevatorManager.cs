namespace ElevatorSimulator.Interfaces
{
    public interface IElevatorManager
    {
        public IElevator GetAvailableElevator();
        public void AddElevator(IElevator elevator);
        public int Count { get; }
    }
}