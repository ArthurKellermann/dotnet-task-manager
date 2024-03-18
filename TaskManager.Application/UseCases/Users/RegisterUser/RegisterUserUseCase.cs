using TaskManager.Domain.Common.CustomExceptions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.RegisterUser
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

      
        public async Task<User> Execute(User userData)
        {
            if (userData == null)
                throw new ArgumentNullException(nameof(userData));

            try
            {
                User user = await userRepository.Register(userData);

                if (user == null)
                    throw new UserRegistrationException("Could not register the user.");

                return user;
            }
            catch (Exception e)
            {
                throw new UserRegistrationException("Error during the user registration: ", e);
            }
        }
    }
}
