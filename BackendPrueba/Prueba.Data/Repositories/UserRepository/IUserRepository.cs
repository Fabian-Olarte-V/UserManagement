using Prueba.Model.AggregateModels;

namespace Prueba.Data.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User Add(User user);    
        User ValidateUser(string username);
    }
}
