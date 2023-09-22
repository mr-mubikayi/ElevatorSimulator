using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class HighSpeedElevatorManager : IElevatorManager
    {
        private readonly List<IElevator> _elevators = new List<IElevator>();

        public IElevator GetAvailableElevator()
        {
            // For simplicity, returning the first available elevator.
            // TODO: More sophisticated logic can be added here.
            return _elevators.FirstOrDefault();
        }

        public void AddElevator(IElevator elevator)
        {
            _elevators.Add(elevator);
        }

        public int Count => _elevators.Count;
    }
}
