Purpose of this repository is to demonstrate sample automated tests implemented using the GameDriver Tool within the Unity. Tests are configured for the project 'The Explorer: 3D Game Kit' available at: https://learn.unity.com/project/3d-game-kit. In order to set up the test environment, it is necessary to configure Game Driver, which is available at: https://gamedriver.io/.

Important notice is that the code wasn't created in the most effective way; it was more about showcasing different Game Driver and NUnit possibilities.

Tests maintain following logic: Path Class contains core logic, including the highly useful XHierarchy string, along with custom methods created to streamline test execution and game navigation.

SetupCloseApplication and SetupDisconnectClient classes are derived from the Path class. They are designed to enable the configuration of unit tests without the need for passing Setup/TearDown attributes. Additionally, they provide fundamental test project logic.

SmokeTests folder contains subfolders for Level1, Level2, and UI, each containing functional test scripts designed to verify specific functionalities of the game. These tests also serve to demonstrate various GameDriver methods and NUnit library capabilities, such as using TestCaseSource to conduct tests with different parameters.
