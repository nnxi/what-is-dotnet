namespace SimpleCrud.Users;

public static class UserEndPoints
{
    public static void MapUserEndPoints(this IEndpointRouteBuilder app)
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
        return Results.Ok();
    }
}