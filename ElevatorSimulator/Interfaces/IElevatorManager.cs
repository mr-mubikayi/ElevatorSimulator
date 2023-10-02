using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Interfaces
{
    /// <summary>
    /// Provides the contract for managing multiple elevator instances.
    /// </summary>
    public interface IElevatorManager
    {
        /// <summary>
        /// Gets the total number of elevators being managed.
        /// </summary>
        /// <value>The count of elevators.</value>
        int ElevatorsCount { get; }

        /// <summary>
        /// Adds a new elevator to the manager.
        /// </summary>
        /// <param name="elevator">The elevator instance to be added.</param>
        /// <remarks>
        /// This method allows the system to dynamically add elevators for management.
        /// </remarks>
        void AddElevator(IElevator elevator);

        /// <summary>
        /// Retrieves all elevators that are currently being managed.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="IElevator"/> instances.</returns>
        IEnumerable<IElevator> GetAllElevators();

        /// <summary>
        /// Fetches an available elevator based on the specified current floor number.
        /// </summary>
        /// <param name="currentFloorNumber">The floor level from which an available elevator is requested.</param>
        /// <returns>An <see cref="IElevator"/> instance if available; otherwise, null.</returns>
        /// <remarks>
        /// The underlying logic for determining the "availability" of an elevator can be implemented based on various criteria,
        /// such as the nearest elevator, the least occupied, etc.
        /// </remarks>
        IElevator? GetAvailableElevator(FloorLevel currentFloorNumber);
    }
}
