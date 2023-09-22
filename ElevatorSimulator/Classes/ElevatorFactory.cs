using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class ElevatorFactory
    {
        private readonly Dictionary<ElevatorType, IElevatorManager> _managers;

        public ElevatorFactory()
        {
            _managers = new Dictionary<ElevatorType, IElevatorManager>
            {
                { ElevatorType.Passenger, new PassengerElevatorManager() },
                { ElevatorType.HighSpeed, new HighSpeedElevatorManager() }
            };
        }

        public IElevator GetElevator(ElevatorType type)
        {
            if (_managers.TryGetValue(type, out var manager))
            {
                return manager.GetAvailableElevator();
            }

            throw new ArgumentException($"No manager found for elevator type {type}", nameof(type));
        }

        public void AddElevators(ElevatorType type, int count)
        {
            if (_managers.TryGetValue(type, out var manager))
            {
                for (int i = 0; i < count; i++)
                {
                    switch (type)
                    {
                        case ElevatorType.Passenger:
                            manager.AddElevator(new PassengerElevator());
                            break;
                        case ElevatorType.HighSpeed:
                            manager.AddElevator(new HighSpeedElevator());
                            break;
                    }
                }
            }
        }
    }
}
