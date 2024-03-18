using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.GetUsers;
public class GetUsersUseCase
{
    private readonly IUserRepository userRepository;

    public async Task<List<User>> Execute()
    {
        List<User> users = await this.userRepository.GetAll();

        if (users == null || users.Count == 0)
        {
            throw new ArgumentNullException("There are no registered users.");
        }

        return users;
    }
}
