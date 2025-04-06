/// - Imports
using System.Text;

HttpClient _client = new HttpClient();

/// - Initialized Variables 
string url = "http://localhost:5285/";
int errors = 0;
ApiResponse response;

/// - Api Tests - Start
Console.WriteLine("Running API tests...");

try {
    /// - 1° Test - GET Home "/" -> redirect to "/todos" and return all Todos (There isn't any todo)
    response = await GettingTest(url);
    ExpectedResponses emptyGetExpectedResponse = new(200, "[]");
    if(isResponseExpected(response, emptyGetExpectedResponse)) {
        Console.WriteLine("Teste passed - 1° Test - Get Home \"/\" -> redirect to \"/todos\" and return all Todos (There isn't any todo)");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 2° Test - POST "/todos" (Valid Todo) -> Create a new todo
    response = await PostingTest($"{url}todos", "{\"id\": 1, \"name\": \"Salada de Limão\", \"dueDate\": \"2027-12-31\", \"isCompleted\": false }");
    ExpectedResponses correctPostExpectedResponse = new(201, "{\"id\":1,\"name\":\"Salada de Limão\",\"dueDate\":\"2027-12-31T00:00:00\",\"isCompleted\":false}");
    if(isResponseExpected(response, correctPostExpectedResponse)) {
        Console.WriteLine("Teste passed - 2° Test - Post \"/todos\" (Valid Todo) -> Create a new todo");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 3° Test - GET Home "/" -> redirect to "/todos" and return all Todos
    response = await GettingTest(url);
    ExpectedResponses notEmptyGetExpectedResponse = emptyGetExpectedResponse with {Content = "[{\"id\":1,\"name\":\"Salada de Limão\",\"dueDate\":\"2027-12-31T00:00:00\",\"isCompleted\":false}]"};
    if(isResponseExpected(response, notEmptyGetExpectedResponse)) {
        Console.WriteLine("Teste passed - 3° Test - Get Home \"/\" -> redirect to \"/todos\" and return all Todos");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 4° Test - GET "/todos/id" (Valid Id) -> Return Todo With Id
    response = await GettingTest(url, 1);
    ExpectedResponses notEmptyWithIdGetExpectedResponse = emptyGetExpectedResponse with {Content = "{\"id\":1,\"name\":\"Salada de Limão\",\"dueDate\":\"2027-12-31T00:00:00\",\"isCompleted\":false}"};
    if(isResponseExpected(response, notEmptyWithIdGetExpectedResponse)) {
        Console.WriteLine("Teste passed - 4° Test - Get Home \"/todos/id\" (Valid Id) -> Return Todo With Id");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 5° Test - POST "/todos" (Repeated Todo) -> Error "A Task With Same Id Has Already Been Added"
    response = await PostingTest($"{url}todos", "{\"id\": 1, \"name\": \"Salada de Limão\", \"dueDate\": \"2027-12-31\", \"isCompleted\": false }");
    ExpectedResponses repeatedPostExpectedResponse = new(409, "{\"message\":\"A Task With Same Id Has Already Been Added\"}");
    if(isResponseExpected(response, repeatedPostExpectedResponse)) {
        Console.WriteLine("Teste passed - 5° Test - Post \"/todos\" (Repeated Todo) -> Error \"A Task With Same Id Has Already Been Added\"");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 6° Test - POST "/todos" (Invalid DateTime "Past") -> Error "DueDate is invalid"
    response = await PostingTest($"{url}todos", "{\"id\": 4, \"name\": \"Salada de Limão\", \"dueDate\": \"2020-12-31\", \"isCompleted\": false }");
    ExpectedResponses invalidDateTimePostExpectedResponse = repeatedPostExpectedResponse with {Content = "{\"message\":\"DueDate is invalid\"}"};
    if(isResponseExpected(response, invalidDateTimePostExpectedResponse)) {
        Console.WriteLine("Teste passed - 6° Test - Post \"/todos\" (Invalid DateTime \"Past\") -> Error \"DueDate is invalid\"");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 7° Test - DELETE "/todos/id" (Valid Id) -> Delete Todo With Id
    response = await DeletingTest(url, 1);
    ExpectedResponses validDeleteExpectedResponse = new(204, "");
    if(isResponseExpected(response, validDeleteExpectedResponse)) {
        Console.WriteLine("Teste passed - 7° Test - Delete \"/todos/id\" (Valid Id) -> Delete Todo With Id");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 8° Test - DELETE "/todos/id" (Invalid Id) -> Error "There is no Task with id - id"
    response = await DeletingTest(url, 5);
    ExpectedResponses invalidDeleteExpectedResponse = new(404, "{\"message\":\"There is no Task with id - 5\"}");
    if(isResponseExpected(response, invalidDeleteExpectedResponse)) {
        Console.WriteLine("Teste passed - 8° Test - Delete \"/todos/id\" (Invalid Id) -> Error \"There is no Task with id - id\"");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 9° Test - GET "/todos/id" (Invalid Id) -> Error "There is no Task with id - id"
    response = await GettingTest(url, 5);
    ExpectedResponses invalidIdGetExpectedResponse = new(404, "{\"message\":\"There is no Task with id - 5\"}");
    if(isResponseExpected(response, invalidIdGetExpectedResponse)) {
        Console.WriteLine("Teste passed - 9° Test - Get \"/todos/id\" (Invalid Id) -> Error \"There is no Task with id - id\"");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - 10° Test - POST "/todos" (Null Name) -> Error "Received Body is Wrong"
    response = await PostingTest($"{url}todos", "{\"id\": 1, \"dueDate\": \"2027-12-31\", \"isCompleted\": false }");
    ExpectedResponses nullPostExpectedResponse = new(400, "{\"message\":\"Received Body is Wrong\"}");
    if(isResponseExpected(response, nullPostExpectedResponse)) {
        Console.WriteLine("Teste passed - 10° Test - Post \"/todos\" (Null Name) -> Error \"Received Body is Wrong\"");
    } else {
        Console.WriteLine("Something Wen't Wrong. Check Console Above Lines for more info.");
        errors++;
    }

    /// - Api Tests - End
    Console.WriteLine($"\nTests completed with: \n{errors} Errors && {10-errors} Passed Tests");

/// - Error Handling
} catch(Exception e) {
     Console.WriteLine($"\n{e.Message}");
     Console.WriteLine($"\nTests completed with: \n{errors} Errors && {10-errors} Passed Tests");
     return;
};

/// - Request Functions
async Task<ApiResponse> GettingTest(string url, int? id = null) {
    try {
        var getResponse = await _client.GetAsync(id == null? url : $"{url}todos/{id}");
        return new ApiResponse((int)getResponse.StatusCode, await getResponse.Content.ReadAsStringAsync());
    } catch(HttpRequestException e) {
        throw new Exception(e.Message);
    }
}

async Task<ApiResponse> PostingTest(string url, string body) {
    try {
        HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
        var posResponse = await _client.PostAsync(url, content);
        return new ApiResponse((int)posResponse.StatusCode, await posResponse.Content.ReadAsStringAsync());
    } catch(HttpRequestException e) {
        throw new Exception(e.Message);
    }
}

async Task<ApiResponse> DeletingTest(string url, int? id = null) {
    try {
        var deleteResponse = await _client.DeleteAsync($"{url}todos/{id}");
        return new ApiResponse((int)deleteResponse.StatusCode, await deleteResponse.Content.ReadAsStringAsync());
    } catch(HttpRequestException e) {
        throw new Exception(e.Message);
    }
}

/// - Compare Responses Function
bool isResponseExpected(ApiResponse apiResponse, ExpectedResponses expectedResponse) {
    if(apiResponse.StatusCode == expectedResponse.StatusCode && apiResponse.Content == expectedResponse.Content) {
        Console.WriteLine($"\nApi Response Status  - {apiResponse.StatusCode} == Expected Response Status  - {expectedResponse.StatusCode}");
        Console.WriteLine($"Api Response Content - {apiResponse.Content} == Expected Response Content - {expectedResponse.Content}");
        return true;
    } else {
        Console.WriteLine($"\nApi Response Status  - {apiResponse.StatusCode} {(apiResponse.StatusCode != expectedResponse.StatusCode? "!=" : "==")} Expected Response Status  - {expectedResponse.StatusCode}");
        Console.WriteLine($"Api Response Content - {apiResponse.Content} {(apiResponse.Content != expectedResponse.Content? "!=" : "==")} Expected Response Content - {expectedResponse.Content}");
        return false;
    }
}

/// - Definition of Classes and Records
public class ApiResponse { /// - ApiResponse Class - Store Api Responses - Can be Modified and Reused
    private int? _statusCode;
    private string? _content;

    public int? StatusCode => _statusCode;
    public string? Content => _content;

    public ApiResponse(int statusCode, string content) {
        _statusCode = statusCode;
        _content = content;
    }
}

/// - ExpectedResponses Record - Stores Predefined Responses that we Expect From the Api - Cannot be Modified 
public record ExpectedResponses(int StatusCode, string Content); 