using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = _userService.GetUser(id);
        if (user == null) return NotFound();
        return Ok(user);
        
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser (int id, [FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var existingUser = _userService.GetUser(id);
        if (existingUser == null)
        {
            return NotFound();
        }
        
        existingUser.Name = user.Name;
        existingUser.Password = user.Password;

        _userService.UpdateUser(existingUser);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userService.DeleteUser(id);
        return NoContent();
    }
}
