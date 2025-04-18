# MicrosoftLearn-TodoApi

A simple API developed to explore and learn ASP.NET Core and C#. This project extends the foundational concepts from Microsoft's learning resources by incorporating additional functionalities such as automated tests, data validations, and platform-specific scripts (Windows and Gnome-Based Linux Distros) for running the application and tests.

## Api Documentation
Access the Api documentation on [Api-Doc.md](Api-Doc.md) file.

## Tests Documentation
Access the Api documentation on [Tests-Doc.md](Tests-Doc.md) file.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Create, Read and Delete Operations**: Manage to-do items with Create, Read, and Delete functionality.
- **Data Validation**: Ensures basic data validity through implemented Endpoint Filters and Logic.
- **Automated Testing**: Includes a suite of tests to verify the correctness of API endpoints and functionalities.
- **Cross-Platform Execution**: Provides `Run.bat` and `Run.sh` scripts to facilitate running the API and tests on Windows and GNOME-based Linux distributions, respectively.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download): Ensure that the appropriate version is installed for building and running the application.
- [Git](https://git-scm.com/downloads): For cloning the repository.
- A terminal or command prompt.

## Getting Started

Follow these steps to set up and run the project:

1. **Clone the Repository**:

  - ```bash
    git clone https://github.com/Twoguini/MicrosoftLearn-TodoApi.git
    ```

2. **Running API and Tests**:
  - Windows:
    ```bash 
    cd MicrosoftLearn-TodoApi
    .\Run.bat
    ```

  - Gnome Based Distros:
    ```bash
    cd MicrosoftLearn-TodoApi
    chmod +x ./Run.sh
    ./Run.sh
    ```

2. **Running Separately**:
  - Windows:
    ```bash
    cd MicrosoftLearn-TodoApi
    ```
    - Api:
      ```bash
      cd Api-Task
      dotnt run
      ```

    - Tests:
      ```bash
      cd ApiTesting
      dotnet run
      ```

  - Gnome Based Distros:
    ```bash
    cd MicrosoftLearn-TodoApi
    ```
    - Api:
      ```bash
      cd Api-Task
      dotnet run
      ```

    - Tests:
      ```bash
      cd ApiTesting
      dotnet run
      ``` 

These scripts will build the project and start the API. By default, the API runs at: **http://localhost:5285**.

## Project Structure

The project's structure is minimal and organized as follows:

- `Api-Task`: Contains the Api source code.
- `ApiTesting`: Contains the automated test project.
- `Run.*`: Scripts to build and start both Api and Tests. 

The remaining files follows standart ASP.NET Project structures.

## Contributing

As mentioned, this is a basic project focused on learning about these technologies. Contributions and tips are welcome!! 

- Commenting: 
  1. Visit the github project [Discussion Page](https://github.com/Twoguini/MicrosoftLearn-TodoApi/discussions).
  2. Open a new discussion or check if a similar topic already exists.
  3. Share your feedback and tips.

- Contributing: 
  1. Visit the main github project [Page](https://github.com/Twoguini/MicrosoftLearn-TodoApi).
  2. Fork the repo.
  3. Make your changes and commit them with descriptive messages.
  4. Push your changes to your fork.

Pull requests and merges won't be accepted, as this is a personal study repo. However, your tips and contributions will help with my learning and growth!

## License 

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
