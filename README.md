# MicrosoftLearn-TodoApi

A simple API developed to explore and learn ASP.NET Core and C#. This project extends the foundational concepts from Microsoft's learning resources by incorporating additional functionalities such as automated tests, data validations, and platform-specific scripts (Windows and Gnome-Based Linux Distros) for running the application and tests.

## Api Documentation
Access the Api documentation on [Api-Doc](Api-Doc.md) file.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Running the API](#running-the-api)
  - [Running Tests](#running-tests)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Create, Read and Delete Operations**: Manage to-do items with Create, Read, and Delete functionalities.
- **Data Validation**: Ensures basic validity of data through implemented Endpoint Filters and Logic.
- **Automated Testing**: Includes a suite of tests to verify the correctness of API endpoints and functionalities.
- **Cross-Platform Execution**: Provides `Run.bat` and `Run.sh` scripts to facilitate running the API and tests on Windows and Gnome-Based Linux Distros.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download): Ensure the appropriate version is installed for building and running the application.
- [Git](https://git-scm.com/downloads): For cloning the repository.
- A terminal or command prompt.

## Getting Started

Follow these steps to set up and run the project:

1. **Clone the Repository**:

  - `git clone https://github.com/Twoguini/MicrosoftLearn-TodoApi.git`

2. **Running API and Tests**:
  - Windows:\
    `cd MicrosoftLearn-TodoApi`\
    `.\Run.bat`

  - Gnome Based Distros:\
    `cd MicrosoftLearn-TodoApi`\
    `./Run.sh`

2. **Running Separately**:
  - Windows:
    `cd MicrosoftLearn-TodoApi`
    - Api:\
      `cd Api-Task`\
      `dotnet run`

    - Tests:\
      `cd ApiTesting`\
      `dotnet run`

  - Gnome Based Distros:
    `cd MicrosoftLearn-TodoApi`
    - Api:\
      `cd Api-Task`\
      `dotnet run`

    - Tests:\
      `cd ApiTesting`\
      `dotnet run`

These scripts will build the project and start the API. By default, the API will be accessible at http://localhost:5000.

## Project Structure

Project's structure is simple and organized as follows: 

- `Api-Task`: Contains the Api source code.
- `ApiTesting`: Houses the automated test project.
- `Run.*`: Scripts to build and start both Api and Tests. 

The remaining files follows standart ASP.NET Project structures.

## Contributing

As said, this is a basic project focused on learning about these tecnologies. So contributions and tips are welcome!! 

- Commenting: 
  1. Visit the github project [Discussion Page](https://github.com/Twoguini/MicrosoftLearn-TodoApi/discussions).
  2. Open a new discussion or check if a similar topic already exists.
  3. Share your feedback and tips.

- Contributing: 
  1. Visit the main github project [Page](https://github.com/Twoguini/MicrosoftLearn-TodoApi).
  2. Fork the repo.
  3. Make yout changes and commit them with descriptive messages.
  4. Push your changes to your fork.

Pull requests and merges won't be accepted, as this is a personal study repo. However, your tips and contributions will help with my learning and growth!

## License 

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.