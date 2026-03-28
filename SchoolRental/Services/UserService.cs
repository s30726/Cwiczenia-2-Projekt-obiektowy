using SchoolRental.Models.Users;

namespace SchoolRental.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }
    
    public List<User> GetAll()
    {
        return _users;
    }
}