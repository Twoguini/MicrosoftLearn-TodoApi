# Api Documentation 

A simple API developed to explore and learn ASP.NET Core and C#. This project extends the foundational concepts from Microsoft's learning resources by incorporating additional functionalities such as automated tests, data validations, and platform-specific scripts (Windows and Gnome-Based Linux Distros) for running the application and tests.

This Api Create, Read and Delete To-do Tasks and uses a `Record` as a **DB Mockup**. 

As intendend by Microsoft when creating this "Step by Step" tutorial, i used this Api to learn and develop my habilities on C# and ASP.NET. This Api isn't only a result of that tutorial, i went far and created some features by myself.

## Table of Contents

- [Middlewares and Filters](#middlewares-and-filters)
- [Endpoints](#endpoints)
- [Req-Res Formats](#req---res-formats)
- [Error Handling](#error-handling)
- [Sample Usage](#sample-usage)

## Middlewares and Filters

  ### Middlewares
  - **Home Page Redirect Middleware**: Redirect `/` path to `/todos`. `/todos` is the base path this Api uses.
  - **Logging Middleware**: Logs Requisition and Responses `Method`, `Path`, `DateTime Now` and `Status Code`.

  ### Endpoint Filters
  - **Post Filter**:
    1. Validates that the due date is not in the past.\
      -> If Invalid: Returns - `409 - DueDate is invalid`.

    2. If there isn't any recorded Task with the same Id.\
      If there is, This Task is invalid - `409 - A Task With Same Id Has Already Been Added`.

    3. If the received name isn't null.\
      If it is, This Task is invalid - `400 - Received Body is Wrong`.

    See [Error Handling](#error-handling) for more.

## Endpoints

By default, the Api runs at: **http://localhost:5285**.

  ### Get:
  `"/todos"`:\
  ✅ **`200 - OK` - Returns all Todo items as a list[]**.

  `"/todos/{id}"`:\
  ✅ **`200 - OK` - Returns the Todo with the specified ID**.\
  ❌ **`404 - Not Found` - If no Task with the given ID exists**.\
  -> `Response: {"message": "There is no Task with id - {id}" }`

  ### Post:
  ✅ `201 - Created` – If the task is valid and successfully created.  
  ❌ `400 - Bad Request` – If required fields are missing or invalid.  
  ❌ `409 - Conflict` – If task due date is in the past or if the ID already exists.  
  → See [Error Handling](#error-handling) for more.
  
  ### Delete:
  ✅ `204 - No Content` – If the task with the specified ID was found and deleted.  
  ❌ `404 - Not Found` – If no task with that ID exists.  
  → `Response: { "message": "There is no Task with id{id}" }`

## Req - Res Formats

  ### Request Example (POST `/todos`):

  ```json
  {
    "id": 1,
    "name": "Take out the trash",
    "dueDate": "2025-12-31T00:00:00",
    "isCompleted": false
  }
  ```

  ### Response Example (GET `/todos`):

  ```json
  [
    {
      "id": 1,
      "name": "Take out the trash",
      "dueDate": "2025-12-31T00:00:00",
      "isCompleted": false
    }
  ]
  ```

  ### Response Example (GET `/todos/1`):

  ```json
  {
    "id": 1,
    "name": "Take out the trash",
    "dueDate": "2025-12-31T00:00:00",
    "isCompleted": false
  }
  ```

## Error Handling

Validations and Filters ensure only valid tasks are processed:

- POST `/todos`:
  - The non existence of Id on the Request body will result on a Id 0 Task (an Integer value can't be null).
  - The non existence of IsCompleted on the Request body will result on a False value (a boolean with no value passed is considered false).
  - The non existence of DueDate on the Request body will result on `409 - DueDate is invalid` error (when not received, DueDate counts as the first DateTime possible "1/1/0001 12:00:00 AM").

All invalid inputs and erros will return appropriate HTTP Status Codes with informative messages using the following error object structure:
```json
  {
    "message": "Error Description"
  }
```

## Sample Usage

There are many ways of testing the Api.
- cURL: 
  ```bash
  curl http://localhost:5285/todos
  ```

- Use Postman, Thunder Client, or any request method.

- Feel free to use and modify my test routine, check its documentation on [Tests-Doc](Tests-Doc.md).

Check [Request and Response Formats](#req---res-formats).