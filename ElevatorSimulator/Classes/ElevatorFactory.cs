using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    /// <summary>
    /// A factory for managing and creating instances of different types of elevators.
    /// </summary>
    public class ElevatorFactory
    {
        private readonly Dictionary<ElevatorType, IElevatorManager> _elevatorManagers;
        private readonly IConsoleService _consoleService;

        public ElevatorFactory(IConsoleService consoleService)
        {
            _consoleService = consoleService;

            _elevatorManagers = new Dictionary<ElevatorType, IElevatorManager>
            {
                { ElevatorType.Passenger, new PassengerElevatorManager(_consoleService) }

                 // Additional elevator types can be initialized here.                
            };
        }

        /// <summary>
        /// Retrieves an available elevator of the specified type, based on the given passenger floor number.
        /// </summary>
        /// <param name="type">The type of elevator requested.</param>
        /// <param name="passengerFloorNumber">The floor number where the elevator is being requested from.</param>
        /// <returns>An available <see cref="IElevator"/> instance or null if none are available.</returns>
        public IElevator? GetElevator(ElevatorType type, FloorLevel passengerFloorNumber)
        {
            try
            {
                if (_elevatorManagers.TryGetValue(type, out var manager))
                    return manager.GetAvailableElevator(passengerFloorNumber);

                _consoleService.WriteLine(string.Format(DisplayTexts.NO_AVAILABLE_MANAGER_TEXT, type));

                return null;
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_GETTING_ELEVATOR_TYPE_TEXT, type, ex.Message));
                return null;
            }
        }

        /// <summary>
        /// Adds a specified number of new elevators of a given type to the factory.
        /// </summary>
        /// <param name="type">The type of elevators to be added.</param>
        /// <param name="count">The number of elevators to add.</param>
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
                                manager.AddElevator(new PassengerElevator(_consoleService));
                                break;

                                // Additional elevator types here.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_ADDING_ELEVATOR_TYPE_TEXT, type, ex.Message));
            }
        }

        /// <summary>
        /// Retrieves all elevators of a specified type that are managed by the factory.
        /// </summary>
        /// <param name="type">The type of elevators to retrieve.</param>
        /// <returns>A collection of <see cref="IElevator"/> instances of the specified type.</returns>
        public IEnumerable<IElevator> GetAllElevatorsByType(ElevatorType type)
        {
            try
            {
                if (_elevatorManagers.TryGetValue(type, out var manager))
                    return manager.GetAllElevators();

                _consoleService.WriteLine(string.Format(DisplayTexts.NO_AVAILABLE_MANAGER_TEXT, type));

                return new List<IElevator>();
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_RETRIEVING_ELEVATOR_TYPE_TEXT, type, ex.Message));
                return new List<IElevator>();
            }
        }
    }
}