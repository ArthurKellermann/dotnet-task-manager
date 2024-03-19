using TaskManager.Domain.Common.CustomExceptions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.GetUserById
{
    public class GetUserByIdUseCase
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> Execute(int id)
        {
            User user = await this.userRepository.GetById(id);

            if (user == null)
            {
                throw new UserDoesNotExistException("User does not exist.");
            }

            return user;
        }
    }
}
