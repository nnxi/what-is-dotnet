namespace SimpleCrud.Users;

public class UserService
{
    private readonly List<CreateUserRequest> _db = new List<CreateUserRequest>()
    {
        new CreateUserRequest("user01", "Kim", "pass01!"),
        new CreateUserRequest("user02", "Lee", "pass02!"),
        new CreateUserRequest("user03", "Park", "pass03!"),
        new CreateUserRequest("user04", "Choi", "pass04!"),
        new CreateUserRequest("user05", "Jung", "pass05!"),
        new CreateUserRequest("user06", "Kang", "pass06!"),
        new CreateUserRequest("user07", "Cho", "pass07!"),
        new CreateUserRequest("user08", "Yoon", "pass08!"),
        new CreateUserRequest("user09", "Jang", "pass09!"),
        new CreateUserRequest("user10", "Lim", "pass10!")
    }; 


    public List<UserResponse> GetAll()
    {
        return _db.Select(u => new UserResponse(u.UserId, u.UserName)).ToList();
    }

    public void CreateUser(CreateUserRequest u)
    {
        if (string.IsNullOrWhiteSpace(u.UserId) ||
            string.IsNullOrWhiteSpace(u.UserName) ||
            string.IsNullOrWhiteSpace(u.Password))
        {
            throw new ArgumentException("Some required fields are missing.");
        }

        if (_db.Any(x => x.UserId == u.UserId))
        {
            throw new InvalidOperationException("This Id already exists.");
        }

        _db.Add(u);
    }
}