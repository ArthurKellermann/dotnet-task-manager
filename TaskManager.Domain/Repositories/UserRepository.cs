using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Interfaces;
using TaskManager.Infrastructure.Database;

namespace TaskManager.Domain.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskManagerDbContext _dbContex;
    public UserRepository(TaskManagerDbContext taskManagerDbContext)
    {
        _dbContex = taskManagerDbContext;
    }
    public async Task<User> Register(User user)
    {
        await _dbContex.AddAsync(user);
        await _dbContex.SaveChangesAsync();

        return user;
    }
    public async Task<List<User>> GetAll()
    {
        return await _dbContex.Users.ToListAsync();
    }
    public async Task<User> GetById(int id)
    {
        User user = await _dbContex.Users.FirstOrDefaultAsync(user => user.Id == id);

        if (user == null)
        {
            throw new NotImplementedException();
        }

        return user;
    }
    public async Task<User> Update(User user, int id)
    {
        User userById = await GetById(user.Id);

        if (userById == null)
        {
            throw new NotImplementedException($"User (id: {id}) does not exists.");
        }

        userById.Name = user.Name;
        userById.Email = user.Email;

        _dbContex.Users.Update(userById);
        await _dbContex.SaveChangesAsync();

        return userById;
    }

    public async Task<bool> Delete(int id)
    {
        User userById = await GetById(id);

        if (userById == null)
        {
            throw new NotImplementedException($"User (id: {id}) does not exists.");
        }

        _dbContex.Users.Remove(userById);
        await _dbContex.SaveChangesAsync();

        return true;

    }



}

