using System;
using System.Threading.Tasks;
using TaskManager.Domain.Common.CustomExceptions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> Execute(User user, int id)
        {
            User userExists = await this.userRepository.GetById(id);

            try
            {
                if (userExists == null)
                {
                    throw new UserDoesNotExistException("User does not exist.");
                }

                await this.userRepository.Update(user, id);

                return user;
            }
            catch (UserDoesNotExistException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Error during the user registration: " + e.Message, e);
            }
        }
    }
}
