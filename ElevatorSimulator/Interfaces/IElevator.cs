using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Interfaces
{
    /// <summary>
    /// Represents the contract for an elevator's operations and status information.
    /// </summary>
    public interface IElevator
    {
        /// <summary>
        /// Gets the unique identifier for the elevator.
        /// </summary>
        /// <value>The unique identifier of the elevator.</value>
        Guid Id { get; }

        /// <summary>
        /// Gets the current floor where the elevator is located.
        /// </summary>
        /// <value>The current floor of the elevator.</value>
        FloorLevel CurrentFloor { get; }

        /// <summary>
        /// Gets the current movement direction of the elevator.
        /// </summary>
        /// <value>The movement direction, e.g., Up, Down, or Stationary.</value>
        MovementStatus Direction { get; }

        /// <summary>
        /// Indicates whether the elevator is currently moving.
        /// </summary>
        /// <value><c>true</c> if the elevator is moving; otherwise, <c>false</c>.</value>
        bool IsMoving { get; }

        /// <summary>
        /// Indicates whether the elevator door is currently open.
        /// </summary>
        /// <value><c>true</c> if the door is open; otherwise, <c>false</c>.</value>
        bool IsDoorOpened { get; }

        /// <summary>
        /// Gets the current number of passengers inside the elevator.
        /// </summary>
        /// <value>The number of passengers.</value>
        int PassengerCount { get; }

        /// <summary>
        /// Gets the maximum number of passengers the elevator can carry.
        /// </summary>
        /// <value>The maximum number of passengers.</value>
        int MaxPassengerCount { get; }

        /// <summary>
        /// Requests the elevator to come to the specified floor.
        /// </summary>
        /// <param name="currentFloorLevel">The floor from which the elevator is being called.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CallElevator(FloorLevel currentFloorLevel);

        /// <summary>
        /// Directs the elevator to go to the desired floor.
        /// </summary>
        /// <param name="desiredFloorLevel">The target floor level.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task GoToFloor(FloorLevel desiredFloorLevel);

        /// <summary>
        /// Opens the elevator's door.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task OpenDoor();

        /// <summary>
        /// Closes the elevator's door.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CloseDoor();

        /// <summary>
        /// Adds passengers to the elevator.
        /// </summary>
        /// <remarks>
        /// The implementation should handle the logic for determining how many passengers to add and ensure that it doesn't exceed <see cref="MaxPassengerCount"/>.
        /// </remarks>
        void AddPassengers();

        /// <summary>
        /// Removes passengers from the elevator.
        /// </summary>
        /// <remarks>
        /// The implementation should handle the logic for determining how many passengers to remove.
        /// </remarks>
        void RemovePassengers();
    }
}
