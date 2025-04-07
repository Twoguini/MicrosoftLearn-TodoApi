# Tests Documentation

This document details the automated integration tests built for the Todo API as a complement to the main project described in the [Api-Doc](Api-Doc.md). While the original implementation followed Microsoft's tutorial for building a minimal API, this test suite, along with the overall testing strategy, was developed independently as an extension to deepen my understanding.

Through the creation of these tests, I was able to explore and apply Test-Driven Development (TDD) principles, solidify my backend development skills, and improve my proficiency with C# and ASP.NET Core. The tests go beyond verifying endpoint functionality—they simulate real API usage, handle error scenarios, and serve as a learning tool for good testing practices in .NET development. None of these testing practices were covered in the original Microsoft guide, making this a self-driven and valuable learning addition to the project.

# Api Documentation

You can access the [Api Documentation](Api-Doc.md).

## Table of Contents

- [Enviroment](#enviroment)
- [Strategy](#strategy)
- [Testes and Expected Responses](#testes-and-expected-responses)

## Enviroment
  Running the tests is a simple task and it is covered in the [Getting Started](README.md#getting-started) section. Also, ensure you meet all [Prerequisites](README.md#prerequisites).

  > ⚠️ Running tests without first starting the server will obviously result in exceptions.

  For convenience, use the `Run.bat` or `Run.sh` scripts to start both the API and test project simultaneously.

## Strategy

The test project uses integration testing to verify the behavior of the API by simulating real requests and analyzing the responses. Each test:

- Uses an HTTP client to interact with the API endpoints.
- Validates that responses match expected status codes and data.
- Covers both successful scenarios and common failure conditions (e.g., missing parameters, invalid data, or operations on non-existent resources).
- Is written in a way that the system state is controlled and isolated.
- Tests are ordered to ensure the correct state for each step and to guarantee expected results and behavior.

The number of failures and successful tests is displayed at the end of the execution.

## Testes and Expected Responses

Here is a summary of the main tests and their expected results:

### Successful Scenarios

| **Test Name**                 | **Endpoint**   | **Method** | **Purpose**                                            | **Expected Result**                         |
|-------------------------------|----------------|------------|--------------------------------------------------------|---------------------------------------------|
| `Home Redirect`               | `/` -> `/todos`| GET        | Redirects GET to base url                              | `200 OK` with empty list                    |
| `Retrive a Not Empty List`    | `/` -> `/todos`| GET        | Retrives list after posting a task                     | `200 OK` with a list with one task only     |
| `Retrive Task Using Valid Id` | `/todos/{id}`  | GET        | Retrives a Taks by valid Id                            | `200 OK` with a single task                 |
| `Valid Task Post`             | `/todos`       | POST       | Posts a valid task                                     | `201 Created` with created task             |
| `Delete Task Using Valid Id`  | `/todos/{id}`  | DELETE     | Deletes a Taks by valid Id                             | `204 No Content`                            |

### Failure Scenarios

| **Test Name**                 | **Endpoint**  | **Method** | **Purpose**                                             | **Expected Result**                             |
|-------------------------------|---------------|------------|---------------------------------------------------------|-------------------------------------------------|
| `Get Task Using inValid Id`   | `/todos/{id}` | GET        |  Attempts to retrive a task with non-Existent Id        | `404 Not Found` with Error Message              |
| `Task w/ repeated Id`         | `/todos`      | POST       |  Attempts to post a task using a, existent Id           | `409 Conflict` with Error Message               |
| `Task w/ Past DateTime`       | `/todos`      | POST       |  Attempts to post a task with a past due date           | `409 Conflict` with Error Message               |
| `Null name Task`              | `/todos`      | POST       |  Attempts to post a task with a null or missing name    | `400 Bad Request` with Error Message            |
| `Delete Task Using inValid Id`| `/todos/{id}` | DELETE     |  Attempts to delete a non-existing task                 | `404 Not Found` with Error Message              |

### Test Order

   1. `Home Redirect`
   2. `Valid Task Post`
   3. `Retrive a Not Empty List`
   4. `Retrive Task Using Valid Id`
   5. `Task w/ repeated Id`
   6. `Task w/ Past DateTime`
   7. `Delete Task Using Valid Id`
   8. `Delete Task Using inValid Id`
   9. `Get Task Using inValid Id`
  10. `Null name Task`

Each test case is self-contained and focuses on a single operation or validation rule. These tests were designed to cover all relevant scenarios and operations provided by the API.

See [Error Handling](Api-Doc.md#error-handling) and [Endpoints](Api-Doc.md#endpoints) for more information.
