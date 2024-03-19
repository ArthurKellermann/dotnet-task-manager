using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.DeleteUser;
public class DeleteUserUseCase
{
    private readonly IUserRepository userRepository;

    public DeleteUserUseCase(IUserRepository userRepository)
    {
        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<bool> Execute(int id)
    {
        User user = await this.userRepository.GetById(id);

        if (user == null)
        {
            return false;
        }
        
        await this.userRepository.Delete(id);

        return true;
    }
}
