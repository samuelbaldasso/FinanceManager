using WebApplication1.Entities;

namespace WebApplication1.Services;

public interface IUserService
{
    IEnumerable<User> GetUsers();
    User? GetUser(int id);
    void AddUser(User user);
    void DeleteUser(int id);
    void UpdateUser(User user);
}