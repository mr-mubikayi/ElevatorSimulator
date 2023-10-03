using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    /// <summary>
    /// Manages operations and selection of passenger elevators.
    /// </summary>
    public class PassengerElevatorManager : IElevatorManager
    {
        private readonly List<IElevator> _elevators = new List<IElevator>();
        private readonly IConsoleService _consoleService;

        public int ElevatorsCount => _elevators.Count;

        public PassengerElevatorManager(IConsoleService consoleService)
        {
            _consoleService = consoleService;      
        }

        public void AddElevator(IElevator elevator)
        {
            _elevators.Add(elevator);
        }

        public IElevator? GetAvailableElevator(FloorLevel currentPassengerFloorNumber)
        {
            try
            {
                if (_elevators == null || !_elevators.Any())
                {
                    return null;
                }

                // First, filter out elevators with open doors or those that are full.
                var availableElevators = _elevators
                    .Where(e => !e.IsDoorOpened && e.PassengerCount < e.MaxPassengerCount)
                    .ToList();

                // Check for elevators on the same floor that are not moving.
                var elevatorOnSameFloor = availableElevators
                    .FirstOrDefault(e => e.CurrentFloor == currentPassengerFloorNumber && !e.IsMoving);

                if (elevatorOnSameFloor != null)
                    return elevatorOnSameFloor;

                // Check for elevators moving towards the current floor and will arrive before getting full.
                var movingTowardElevator = availableElevators
                    .FirstOrDefault(e =>
                        ((e.Direction == MovementStatus.Up && e.CurrentFloor < currentPassengerFloorNumber) ||
                         (e.Direction == MovementStatus.Down && e.CurrentFloor > currentPassengerFloorNumber)) &&
                        (e.PassengerCount + (Math.Abs(e.CurrentFloor - currentPassengerFloorNumber)) <= e.MaxPassengerCount)
                    );

                if (movingTowardElevator != null)
                    return movingTowardElevator;

                // For elevators moving away, find the one that will become stationary soonest.
                var soonestAvailableElevator = availableElevators
                    .Where(e =>
                        (e.Direction == MovementStatus.Up && e.CurrentFloor > currentPassengerFloorNumber) ||
                        (e.Direction == MovementStatus.Down && e.CurrentFloor < currentPassengerFloorNumber)
                    )
                    .OrderBy(e =>
                        e.Direction == MovementStatus.Up ?
                        (Enum.GetValues(typeof(FloorLevel)).Cast<FloorLevel>().Max() - e.CurrentFloor) :
                        (int)e.CurrentFloor
                    )
                    .FirstOrDefault();

                if (soonestAvailableElevator != null)
                    return soonestAvailableElevator;

                // If no elevators are moving toward the passenger or will be available soonest,
                // then select the closest stationary elevator.
                var closestElevator = availableElevators
                    .Where(e => !e.IsMoving)
                    .OrderBy(e => Math.Abs(e.CurrentFloor - currentPassengerFloorNumber))
                    .FirstOrDefault();

                return closestElevator;
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_GETTING_ELEVATOR, ex.Message));
                return null;
            }       
        }

        public IEnumerable<IElevator> GetAllElevators()
        {
            try
            {
                return _elevators.AsReadOnly();
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_GETTING_ALL_ELEVATORS, ex.Message));
                return Enumerable.Empty<IElevator>();
            }
        }    
    }
}
