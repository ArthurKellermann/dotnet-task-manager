using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Users.RegisterUser;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody] User user)
    {
        var useCase = new RegisterUserUseCase();

        useCase.Execute(user);

        return Created();
    }
}
