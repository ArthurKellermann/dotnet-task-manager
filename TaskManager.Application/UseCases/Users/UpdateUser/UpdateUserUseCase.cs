using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Application.UseCases.Users.UpdateUser;
public class UpdateUserUseCase
{
    private readonly IUserRepository userRepository;

    public async Task<User> Execute(User user, int id)
    {
        User userExists = await this.userRepository.GetById(id);

        if (userExists == null)
        {
            throw new ArgumentNullException("User does not exists.");
        }

        await this.userRepository.Update(user, id);

        return user;
    }
}
