using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;

namespace TaskManager.Domain.Repositories;
class UserRepository : IUserRepository
{
    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Register(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User user, int id)
    {
        throw new NotImplementedException();
    }
}
