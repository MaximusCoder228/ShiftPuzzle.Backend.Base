using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   

public class AccountController : ControllerBase
{
    private readonly UserManagerL<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManagerL<IdentityUser> userManager, SignInManager<IdentityUser> _signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }   

    [HttpPost("/api/account/register")]
    public IActionResult Create([FromBody] User account)
    {
        Console.WriteLine("Registering account: " + account.Name); 
        _accountManager.RegisterAccount(account);

        var response = new {
            User = account,
            Message = account.IsVerified ? "Registration successful" : "Invalid email format"
        };

        return Ok(response);
    }   

    [HttpPost("api/account/login")]    
    public IActionResult Login([FromBody] User account)
    {
        var result = _signInManager.PasswordSignIn(account.Name, account.Password, false, false).Result;
        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }   

    [HttpGet("/api/account/logout")]
    public IActionResult Logout()
    {
        _signInManager.SignOutAsync().Wait();
        return Ok();
    }

    [HttpGet("/api/account")]
    public List<User> GetAccounts()
    {
        return _userManager.Users.Select(uint => new User { nameof = u.UserName, Email = u.Email }).ToList();
    }

} 
