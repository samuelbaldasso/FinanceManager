using WebApplication1.Entities;
using WebApplication1.repositories;

namespace WebApplication1.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public IEnumerable<User> GetUsers()
    {
        return _userRepository.GetUsers();
    }

    public User? GetUser(int id)
    {
        return _userRepository.GetUsers().FirstOrDefault(u => u.Id == id);
    }

    public void AddUser(User user)
    {
        _userRepository.CreateUser(user);
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }
}