## Elevator Simulator

### Description

Elevator Simulator is a program designed to simulate the operations and management of different types of elevators. Users can interact with the simulator, request elevators from various floors, and monitor elevator statuses. The system incorporates features like efficient elevator selection, passenger management, and operational delays.

### Features

* Real-Time Elevator Status:
  Displays the real-􀆟me status of each elevator, including its current floor, direc􀆟on of movement,
  whether it's in mo􀆟on or sta􀆟onary, and the number of passengers it is carrying.
* Interac􀆟ve Elevator Control: 
  Allows users to interact with the elevators through the console applica􀆟on. Users are able
  to call an elevator to a specific floor and indicate the number of passengers wai􀆟ng on each floor.
* Mul􀆟ple Floors and Elevators Support: 
  Accommodates buildings with mul􀆟ple floors and mul􀆟ple elevators.
  Ensures that elevators can efficiently move between different floors.
* Efficient Elevator Dispatching: 
  Minimizes wait 􀆟mes for passengers and op􀆟mize elevator usage by efficiently directing the nearest available elevator to respond to an
  elevator request
* Passenger Limit Handling: 
  Considers the maximum passenger limit for each elevator. Preventing the elevator from becoming
  overloaded and handling scenarios where addi􀆟onal elevators might be required.
* Considera􀆟on for Different Elevator Types
  Accomodates future extension of elevator types, such as high-speed elevators, glass elevators, and freight elevators.
* Real-Time Opera􀆟on: 
  Ensures that the console applica􀆟on operates in real-􀆟me, providing immediate responses to user
  interac􀆟ons and accurately reflec􀆟ng elevator movements and status.
* Error Management:
  Incorporates error-handling and user prompts to guide the user through the correct sequence of operations.

### Getting Started

### Prerequisites

Ensure you have the .NET Core 7.0 SDK installed.

### Installation

1. Clone the repository:

        git clone https://github.com/<Your-GitHub-Username>/ElevatorSimulator.git

2. Navigate to the project directory and run the program:

        cd ElevatorSimulator
        dotnet run

### Usage

### Main Menu

On startup, the user is presented with three options:

1. Call Elevator: This option lets the user call an elevator to their current floor.
2. Display Elevator Status: This option displays the status of all available elevators, showing their current floor, direction, and passenger count.
3. Exit: This option closes the simulator.
   
Follow the on-screen prompts to interact with the simulator.  

![image](https://github.com/mr-mubikayi/ElevatorSimulator/assets/31312536/1fd316ad-0a4b-4f14-8acb-2d726a678c6a)

### Calling an Elevator

When the user selects option 1 to call an elevator:

They're prompted to enter their current floor.
An available elevator moves to their floor (with a simulated delay).

![image](https://github.com/mr-mubikayi/ElevatorSimulator/assets/31312536/10c1b6b6-70d5-4c41-bd3a-bcaecaefa48c)

### Going to the Desired Floor

Once the elevator arrives, the user is prompted to specify the number of passengers entering the elevator and the desired floor to go to.

![image](https://github.com/mr-mubikayi/ElevatorSimulator/assets/31312536/99b7cddc-3c73-4d07-a7b1-444c9734d561)

### Arriving at the Desired Floor

Once the elevator arrives at the desired floor, the user is prompted to specify the number of passengers exiting the elevator.
The status of the elevator is then updated and displayed on the console.

![image](https://github.com/mr-mubikayi/ElevatorSimulator/assets/31312536/ccd66413-2f24-4b48-ac74-697e0087fa76)

### Displaying the Elevators Status

When the user selects option 2 to display the elevator statuses, the list of all elevators is displayed, showing their ID numbers, current floor, direction, and number of passengers currently in the elevator.

![image](https://github.com/mr-mubikayi/ElevatorSimulator/assets/31312536/a4cfe6fb-f25a-4109-82e4-b054b4430e6d)

### Exiting the Application

Selecting option 3 will result in closing the application.

### Contributing

If you wish to contribute, please create a pull request. Ensure your changes are well-documented.

### License

This project is open-source and provided under the MIT License. See LICENSE for details.

### Acknowledgments

Thank you to all contributors and testers for improving the Elevator Simulator. 
