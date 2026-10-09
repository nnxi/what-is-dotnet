namespace SimpleCrud.Users;

public static class UserEndPoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users"); 

        group.MapGet("/", GetAllUsers);
        group.MapPost("/", CreateUser);
    }

    private static IResult GetAllUsers(UserService service)
    {
        var result = service.GetAll();
        return Results.Ok(new {data = result});
    }

    private static IResult CreateUser(CreateUserRequest req, UserService service)
    {
        try
        {
            service.CreateUser(req);
            return Results.Ok();
        }
        catch (ArgumentException ae)
        {
            return Results.BadRequest(new {message = ae.Message});
        }
        catch (InvalidOperationException ioe)
        {
            return Results.Conflict(new {message = ioe.Message});
        }
    }
}