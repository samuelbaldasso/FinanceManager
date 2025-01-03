using WebApplication1.Entities;

namespace WebApplication1.repositories;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUserById(int id);
    User GetUserByEmail(string email);
    void CreateUser(User user);
    void DeleteUser(int id);
    void UpdateUser(User user);
    
}