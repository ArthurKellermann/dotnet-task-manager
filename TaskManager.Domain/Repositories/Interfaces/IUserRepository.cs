using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories.Interfaces;
interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> Register(User user);
    Task<User> Update(User user, int id);
    Task<bool> Delete(int id);

}
