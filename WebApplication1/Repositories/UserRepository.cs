using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public User GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public void CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();        
    }

    public void DeleteUser(int id)
    {
        var user = GetUserById(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    } 
    
    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }
}