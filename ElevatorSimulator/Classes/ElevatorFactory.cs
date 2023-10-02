using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    public class ElevatorFactory
    {
        private readonly Dictionary<ElevatorType, IElevatorManager> _elevatorManagers;

        public ElevatorFactory()
        {
            _elevatorManagers = new Dictionary<ElevatorType, IElevatorManager>
            {
                { ElevatorType.Passenger, new PassengerElevatorManager() }

                /* 
                    You can Initialize different types of elevators here
                 
                    Example :

                    { ElevatorType.Freight, new FreightElevatorManager() }
                    { ElevatorType.HighSpeed, new HighSpeedElevatorManager() }
                */                   
            };
        }

        public IElevator? GetElevator(ElevatorType type, FloorLevel passengerFloorNumber)
        {
            try
            {
                if (_elevatorManagers.TryGetValue(type, out var manager))
                    return manager.GetAvailableElevator(passengerFloorNumber);

                Console.WriteLine(string.Format(DisplayTexts.NO_AVAILABLE_MANAGER_TEXT, type));
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(DisplayTexts.ERROR_GETTING_ELEVATOR_TYPE_TEXT, type, ex.Message));
                return null;
            }
        }

        public void AddElevators(ElevatorType type, int count)
        {
            try
            {
                if (_elevatorManagers.TryGetValue(type, out var manager))
                {
                    for (int i = 0; i < count; i++)
                    {
                        switch (type)
                        {
                            case ElevatorType.Passenger:
                                manager.AddElevator(new PassengerElevator());
                                break;

                                /* 
                                   You can add different types of elevators here

                                    Example :

                                    case ElevatorType.Freight:
                                        manager.AddElevator(new FreightElevator());
                                        break;
                                    case ElevatorType.HighSpeed:
                                        manager.AddElevator(new HighSpeedElevator());
                                        break;
                                */
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(DisplayTexts.ERROR_ADDING_ELEVATOR_TYPE_TEXT, type, ex.Message));
            }
        }

        public IEnumerable<IElevator> GetAllElevatorsByType(ElevatorType type)
        {
            try
            {
                if (_elevatorManagers.TryGetValue(type, out var manager))
                    return manager.GetAllElevators();

                Console.WriteLine(string.Format(DisplayTexts.NO_AVAILABLE_MANAGER_TEXT, type));
                return new List<IElevator>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(DisplayTexts.ERROR_RETRIEVING_ELEVATOR_TYPE_TEXT, type, ex.Message));
                return new List<IElevator>();
            }
        }
    }
}
