using ElevatorSimulator.Constants;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Helpers;
using ElevatorSimulator.Interfaces;

namespace ElevatorSimulator.Classes
{
    /// <summary>
    /// Implements the IElevator interface
    /// Represents a passenger elevator, handling the operations related to 
    /// moving between floors, opening and closing doors, and managing passengers.
    /// </summary>
    public class PassengerElevator : IElevator
    {
        private readonly Guid _id;
        private readonly IConsoleService _consoleService;
        private bool _isDoorOpened;
        private string _subStringGuid;
        private FloorLevel _currentFloor;
        private MovementStatus _direction;


        public Guid Id => _id;
        public FloorLevel CurrentFloor => _currentFloor;
        public MovementStatus Direction => _direction;
        public bool IsMoving => _direction != MovementStatus.Stationary;
        public bool IsDoorOpened => _isDoorOpened;
        public int PassengerCount { get; private set; }
        public int MaxPassengerCount => ElevatorMaxWeights.PassengerElevator;

        public PassengerElevator(IConsoleService consoleService)
        {
            _id = Guid.NewGuid();
            _isDoorOpened = false;
            _subStringGuid = _id.ToString().Split('-')[0];
            _currentFloor = FloorLevel.One;
            _direction = MovementStatus.Stationary;
            _consoleService = consoleService;
        }

        private async Task MoveElevatorTo(FloorLevel targetFloorLevel)
        {
            SetElevatorDirection(targetFloorLevel);

            DisplayElevatorMovementMessage(targetFloorLevel);

            await OperationDelays.PassengerElevator(null);

            if (_direction != MovementStatus.Stationary)
            {
                _currentFloor = targetFloorLevel;

                _consoleService.WriteLine(string.Format(DisplayTexts.ELEVATOR_ARRIVED_TEXT, _subStringGuid, _currentFloor));
            }
        }

        private void SetElevatorDirection(FloorLevel targetFloorLevel)
        {
            _direction = _currentFloor == targetFloorLevel
                ? MovementStatus.Stationary
                : (_currentFloor < targetFloorLevel ? MovementStatus.Up : MovementStatus.Down);
        }

        private void DisplayElevatorMovementMessage(FloorLevel targetFloorLevel)
        {
            _consoleService.WriteLine(_direction == MovementStatus.Stationary
                ? string.Format(DisplayTexts.ELEVATOR_ALREADY_AT_FLOOR_TEXT, _subStringGuid, _currentFloor)
                : string.Format(DisplayTexts.ELEVATOR_MOVING_TEXT, _subStringGuid, _currentFloor, targetFloorLevel));
        }

        public async Task CallElevator(FloorLevel currentFloorLevel)
        {
            try
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.CALLING_ELEVATOR_TEXT, _subStringGuid));

                await MoveElevatorTo(currentFloorLevel);
                await OpenDoor();

                if (PassengerCount > 0)
                    RemovePassengers();

                AddPassengers();
                await CloseDoor();
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_CALLING_ELEVATOR_TEXT, ex.Message));
            }
        }

        public async Task GoToFloor(FloorLevel desiredFloorLevel)
        {
            try
            {
                await MoveElevatorTo(desiredFloorLevel);
                await OpenDoor();

                if (PassengerCount > 0)
                    RemovePassengers();
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_MOVING_ELEVATOR_TEXT, ex.Message));
            }
        }

        public async Task OpenDoor()
        {
            await HandleDoorOperation(true);
        }

        public async Task CloseDoor()
        {
            await HandleDoorOperation(false);
        }

        private async Task HandleDoorOperation(bool isOpening)
        {
            _consoleService.WriteLine(isOpening ? DisplayTexts.OPENING_DOOR_TEXT : DisplayTexts.CLOSING_DOOR_TEXT);

            await OperationDelays.PassengerElevator(null);

            _isDoorOpened = isOpening;

            _consoleService.WriteLine(isOpening ? DisplayTexts.OPENED_DOOR_TEXT : DisplayTexts.CLOSED_DOOR_TEXT);
        }

        public void AddPassengers()
        {
            try
            {
                HandlePassengerChange(true);
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_ADDING_PASSENGERS_TEXT, ex.Message));
            }
        }

        public void RemovePassengers()
        {
            try
            {
                HandlePassengerChange(false);
            }
            catch (Exception ex)
            {
                _consoleService.WriteLine(string.Format(DisplayTexts.ERROR_REMOVING_PASSENGERS_TEXT, ex.Message));
            }
        }

        private void HandlePassengerChange(bool isAdding)
        {
            var maxChange = isAdding ? MaxPassengerCount - PassengerCount : PassengerCount;
            var actionText = isAdding ? DisplayTexts.ENTERING_TEXT : DisplayTexts.EXITING_TEXT;
            var actionDoneText = isAdding ? DisplayTexts.ENTERED_TEXT : DisplayTexts.EXITED_TEXT;
            var passengerPromptText = string.Format(DisplayTexts.PASSENGER_STATUS_TEXT, _subStringGuid, PassengerCount) +
                                      string.Format(DisplayTexts.PASSENGER_ENTERING_TEXT, actionText, maxChange);

            var passengerCount = ValidNumberChecker.GetValidNumber(passengerPromptText, maxChange, _consoleService);

            PassengerCount = isAdding 
                ? PassengerCount + passengerCount 
                : Math.Max(PassengerCount - passengerCount, 0);

            _consoleService.WriteLine(string.Format(DisplayTexts.PASSENGERS_ACTION_DONE_TEXT, passengerCount, actionDoneText, PassengerCount));
        }
    }
}