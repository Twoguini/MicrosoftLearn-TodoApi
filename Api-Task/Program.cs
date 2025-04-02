/// - Imports
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;

/// - Initializers
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

/// - Middlewares
app.UseRewriter(new RewriteOptions().AddRedirect("^$", "/todos"));
app.Use(async (context, next) => {
  Console.WriteLine($"REQ - [{context.Request.Method}] - {context.Request.Path} - [{DateTime.UtcNow}] - {context.Response.StatusCode}");
  await next(context);
  Console.WriteLine($"RES - [{context.Request.Method}] - {context.Request.Path} - [{DateTime.UtcNow}] - {context.Response.StatusCode}");
});

/// - Variables
var todos = new List<Todo>();

/// - Route Handlers
app.MapGet("/todos", () => todos);

app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound<ErrorMessage>> (int id) => {
  var targetTodo = todos.SingleOrDefault(t => id == t.Id);
  return targetTodo == null 
        ? TypedResults.NotFound(new ErrorMessage($"There is no Task with id - {id}"))
        : TypedResults.Ok(targetTodo);
});

app.MapPost("/todos", Results<Created<Todo>, Conflict> (Todo task) => {

    todos.Add(task);
    return TypedResults.Created("/todos/{id}", task);

}).AddEndpointFilter(async (context, next) => {
  
  if(context.GetArgument<Todo>(0).DueDate < DateTime.UtcNow) {
    return TypedResults.Conflict(new ErrorMessage("DueDate is invalid"));
  } else if(todos.SingleOrDefault(t => context.GetArgument<Todo>(0).Id == t.Id) != null) {
    return TypedResults.Conflict(new ErrorMessage("A Task With Same Id Has Already Been Added"));
  }
  return await next(context);
});

app.MapDelete("/todos/{id}", Results<NoContent, NotFound<ErrorMessage>> (int id) => {  
  return todos.RemoveAll(t => id == t.Id) > 0
    ? TypedResults.NoContent() 
    : TypedResults.NotFound(new ErrorMessage($"There is no Task with id - {id}"));
});

app.Run();

/// - Definitions
public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted);

public class ErrorMessage {
  public string Message { get; } 

  public ErrorMessage(string message) {
    Message = message;
  }
}