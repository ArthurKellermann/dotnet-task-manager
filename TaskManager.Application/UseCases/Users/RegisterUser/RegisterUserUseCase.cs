using TaskManager.Domain.Common.CustomExceptions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.RegisterUser
{
    /// <summary>
    /// Use case for register a new user.
    /// </summary>
    public class RegisterUserUseCase
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Use case constructor.
        /// </summary>
        /// <param name="userRepository">Repositório de usuários.</param>
        public RegisterUserUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// Execute the use case.
        /// </summary>
        /// <param name="userData">User data to be registered.</param>
        /// <returns>The registered user.</returns>
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
