using TaskManager.Domain.Entities;

namespace TaskManager.Application.UseCases.Users.RegisterUser;
public class RegisterUserUseCase
{
    public void Execute(User user)
    {
       if (user == null) throw new ArgumentNullException(nameof(user));



       
    }
    
}
