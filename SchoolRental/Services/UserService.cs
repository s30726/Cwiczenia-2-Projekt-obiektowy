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

    public User? GetById(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}