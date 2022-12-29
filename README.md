# ROV-SIM

Underwater drone simulator, built with the Unity game engine and C#. Made by a group of students as part of the course _Experts in Teamwork_, spring 2022 at NTNU Trondheim.

**Contents**

- [Screenshots](#screenshots)
- [Installation](#installation)
- [Code Structure](#code-structure)

## Screenshots

<p align="center">
    <img alt="Main menu" src="https://raw.githubusercontent.com/eit-nemo-group3/rov-sim/assets/screenshots/main_menu.png">
    <br />
    <em>Main menu</em>
</p>

<br />

<p align="center">
    <img alt="Wreck inspection scenario" src="https://raw.githubusercontent.com/eit-nemo-group3/rov-sim/assets/screenshots/wreck_inspection.png">
    <br />
    <em>Wreck inspection scenario</em>
</p>

<br />

<p align="center">
    <img alt="Coral sampling scenario" src="https://raw.githubusercontent.com/eit-nemo-group3/rov-sim/assets/screenshots/coral_sampling.png">
    <br />
    <em>Coral sampling scenario</em>
</p>

## Installation

Go to the [Releases page](https://github.com/eit-nemo-group3/rov-sim/releases), and follow the instructions to download and install the simulator.

## Code Structure

`Assets/Scripts` contains the C\# game scripts for the simulator. The root namespace is `RovSim`, and contains general stand-alone scripts. It has the following sub-namespaces:

- `RovSim.Menu` contains the logic for the simulator's main menu and pause menu.
- `RovSim.Rov` contains the logic for controlling the ROV.
- `RovSim.Scenarios` contains manager classes for the simulated scenarios.
