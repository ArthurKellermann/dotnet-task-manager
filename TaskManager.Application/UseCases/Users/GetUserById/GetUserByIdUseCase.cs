using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.GetUserById;
public class GetUserByIdUseCase
{
    private readonly IUserRepository userRepository;

    public async Task<User> Execute(int id)
    {
        User user = await this.userRepository.GetById(id);

        if (user == null)
        {
            throw new ArgumentNullException("User does not exists.");
        }

        return user;
    }  
}
