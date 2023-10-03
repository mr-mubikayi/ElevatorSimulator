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
                // Filter out elevators on the same floor and stationary
                var stationaryElevatorsOnSameFloor = _elevators
                    .Where(e => e.CurrentFloor == currentPassengerFloorNumber && e.Direction == MovementStatus.Stationary)
                    .ToList();

                if (stationaryElevatorsOnSameFloor.Any())
                {
                    return stationaryElevatorsOnSameFloor.OrderBy(e => e.PassengerCount).FirstOrDefault();
                }

                // Elevators moving towards the calling floor
                var movingTowardsElevators = _elevators.Where(e =>
                    (currentPassengerFloorNumber > e.CurrentFloor && e.Direction == MovementStatus.Up) ||
                    (currentPassengerFloorNumber < e.CurrentFloor && e.Direction == MovementStatus.Down))
                    .ToList();

                if (movingTowardsElevators.Any())
                {
                    return movingTowardsElevators
                        .OrderBy(e => Math.Abs(e.CurrentFloor - currentPassengerFloorNumber))
                        .ThenBy(e => e.PassengerCount)
                        .FirstOrDefault();
                }

                // Elevators that are stationary but not on the same floor or moving away
                var otherElevators = _elevators.Where(e => e.Direction == MovementStatus.Stationary).ToList();

                if (otherElevators.Any())
                {
                    return otherElevators
                        .OrderBy(e => Math.Abs(e.CurrentFloor - currentPassengerFloorNumber))
                        .ThenBy(e => e.PassengerCount)
                        .FirstOrDefault();
                }

                // If no elevator meets the criteria, return any available elevator (though this shouldn't happen)
                return _elevators.OrderBy(e => Math.Abs(e.CurrentFloor - currentPassengerFloorNumber))
                    .ThenBy(e => e.PassengerCount)
                    .FirstOrDefault();
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
