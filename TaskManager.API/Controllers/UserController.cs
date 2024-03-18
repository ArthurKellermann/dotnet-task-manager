using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Users.DeleteUser;
using TaskManager.Application.UseCases.Users.GetUserById;
using TaskManager.Application.UseCases.Users.GetUsers;
using TaskManager.Application.UseCases.Users.RegisterUser;
using TaskManager.Application.UseCases.Users.UpdateUser;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase registerUserUseCase;
        private readonly GetUsersUseCase getUsersUseCase;
        private readonly GetUserByIdUseCase getUserByIdUseCase;
        private readonly UpdateUserUseCase updateUserUseCase;
        private readonly DeleteUserUseCase deleteUserUseCase;


        public UserController(
            RegisterUserUseCase registerUserUseCase,
            GetUsersUseCase getUsersUseCase,
            GetUserByIdUseCase getUserByIdUseCase,
            UpdateUserUseCase updateUserUseCase,
            DeleteUserUseCase deleteUserUseCase)
        {
            this.registerUserUseCase = registerUserUseCase;
            this.getUsersUseCase = getUsersUseCase;
            this.getUserByIdUseCase = getUserByIdUseCase;
            this.updateUserUseCase = updateUserUseCase;
            this.deleteUserUseCase = deleteUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            var result = await registerUserUseCase.Execute(user);

            return Created("api/user", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await this.getUsersUseCase.Execute();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await this.getUserByIdUseCase.Execute(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var result = await this.updateUserUseCase.Execute(user, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await this.deleteUserUseCase.Execute(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
