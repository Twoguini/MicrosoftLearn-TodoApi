# Api Documentation 

A simple API developed to explore and learn ASP.NET Core and C#. This project extends the foundational concepts from Microsoft's learning resources by incorporating additional functionalities such as automated tests, data validations, and platform-specific scripts (Windows and Gnome-Based Linux Distros) for running the application and tests.

This Api Create, Read and Delete To-do Tasks and uses a `Record` as a **DB Mockup**. 

As intendend by Microsoft when creating this "Step by Step" tutorial, i used this Api to learn and develop my habilities on C# and ASP.NET. This Api isn't only a result of that tutorial, i went far and created some features by myself.

## Table of Contents

- [Middlewares and Filters](#Middlewares-and-Filters)
- [Endpoints](#Endpoints)
- [Req-Res Formats](#Req-Res-Formats)
- [Error Handling](#Error-Handling)
- [Sample Usage](#Sample-Usage)

## Middlewares and Filters

- Home Page Redirect Middleware - Redirect `/` path to `/todos`. `/todos` is the base path this Api use.
- Logging Middleware - Log  `Method`, `Path`, `DateTime Now` and `Status Code`.
- Post Filter - 

## Endpoints

By default, the Api will be accessible at http://localhost:5000.

  ### Get:
  ### Post:
  /// talk about when body doesn't contains Id, IsCompleted or DueDate. Id is an Int so the api receives 0 instead of null, Iscompleted is bool and when a bool is missing, that means false, at least DueDate when not informed, counts as the first possible date Time to be registered 1/1/0001 12:00:00 AM
  ### Delete:

## Req - Res Formats

## Error Handling

## Sample Usage