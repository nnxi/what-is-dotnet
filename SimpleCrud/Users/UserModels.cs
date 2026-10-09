namespace SimpleCrud.Users;


public record CreateUserRequest(string UserId, string UserName, string Password);


public record UserResponse(string UserId, string UserName);