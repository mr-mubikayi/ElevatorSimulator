namespace ElevatorSimulator.Constants
{
    /// <summary>
    /// 
    /// This class initializes all texts displayed in the application.
    /// Different language translations can be added and initialized here if necessary.
    /// 
    /// </summary>
    public static class DisplayTexts
    {
        public static readonly string MAIN_MENU_TEXT = @"
.__________ Main Menu __________.
|                               |
|   1. Call Elevator            |
|   2. Display Elevator Status  |
|   3. Exit                     | 
|_______________________________|

Choose an Option (1, 2, 3): ";
        public static readonly string TITLE_TEXT = "\n       ELEVATOR SIMULATOR";
        public static readonly string ENTER_VALUE_TEXT = "\nPlease Enter a Value.";
        public static readonly string INVALID_OPTION_TEXT = "\nInvalid number. Try again.";
        public static readonly string ENTER_CURRENT_FLOOR_TEXT = "\nEnter Your Current Floor Number (1, 2, 3): ";
        public static readonly string ENTER_DESIRED_FLOOR_TEXT = "\nEnter Desired Floor Number (1, 2, 3): ";
        public static readonly string KEY_PRESS_TEXT = "\nPress any key to continue.\n";
        public static readonly string NO_AVAILABLE_ELEVATOR_TEXT = "\nNo available elevators at the moment. Please wait.";
        public static readonly string PASSENGER_ELEVATOR_TEXT = "\n.__________ Passengers Elevators Status __________.\n";
        public static readonly string ELEVATOR_TEXT = "Elevator: ";
        public static readonly string FLOOR_TEXT = "Floor: ";
        public static readonly string DIRECTION_TEXT = "Direction: ";
        public static readonly string PASSENGERS_TEXT = "Passengers: ";
        public static readonly string NO_AVAILABLE_MANAGER_TEXT = "\nNo manager found for elevator type : {0}";
        public static readonly string CALLING_ELEVATOR_TEXT = "\nCalling elevator {0}...";
        public static readonly string OPENING_DOOR_TEXT = "Opening door...";
        public static readonly string OPENED_DOOR_TEXT = "Door Opened.";
        public static readonly string CLOSING_DOOR_TEXT = "Closing Door...";
        public static readonly string CLOSED_DOOR_TEXT = "Door Closed";
        public static readonly string ENTERING_TEXT = "entering";
        public static readonly string EXITING_TEXT = "exiting";
        public static readonly string ENTERED_TEXT = "entered";
        public static readonly string EXITED_TEXT = "exited";
        public static readonly string PASSENGER_STATUS_TEXT = "\nElevator {0} has {1} passengers ";
        public static readonly string PASSENGER_ENTERING_TEXT = "\nHow many are {0}? ({1} max): ";
        public static readonly string PASSENGER_EXITING_TEXT = "\nHow many are exiting? ({0} max): ";
        public static readonly string PASSENGERS_ACTION_DONE_TEXT = "{0} passengers {1}. Current count: {2}";
        public static readonly string ELEVATOR_ARRIVED_TEXT = "Elevator {0} arrived at floor: {1}";
        public static readonly string ELEVATOR_ALREADY_AT_FLOOR_TEXT = "Elevator {0} already at floor: {1}";
        public static readonly string ELEVATOR_MOVING_TEXT = "Elevator {0} moving from floor {1} to {2}...";
        public static readonly string ERROR_GETTING_ELEVATOR_TYPE_TEXT = "Error getting elevator of type {0}: {1}";
        public static readonly string ERROR_ADDING_ELEVATOR_TYPE_TEXT = "Error adding elevators of type {0}: {1}";
        public static readonly string ERROR_RETRIEVING_ELEVATOR_TYPE_TEXT = "Error retrieving all elevators of type {0}: {1}";
        public static readonly string ERROR_CALLING_ELEVATOR_TEXT = "Error while calling elevator: {0}";
        public static readonly string ERROR_MOVING_ELEVATOR_TEXT = "Error moving elevator to desired floor: {0}";
        public static readonly string ERROR_ADDING_PASSENGERS_TEXT = "Error adding passengers: {0}";
        public static readonly string ERROR_REMOVING_PASSENGERS_TEXT = "Error removing passengers: {0}";
        public static readonly string ERROR_GETTING_ELEVATOR = "An error occurred while trying to get an available elevator: {0}";
        public static readonly string ERROR_GETTING_ALL_ELEVATORS = "An error occurred while trying to retrieve all elevators: {0}";
        public static readonly string ERROR_GETTING_FLOOR_INPUT = "Failed to get floor input. Please try again";
        public static readonly string ERROR_OCCURED = "An unexpected error occurred: {0}";
    }
}