using Prueba.Model.AggregateModels;

namespace Prueba.Data.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public User Add(User user)
        {
            var userSaved = _databaseContext.Users.Add(user).Entity;   
            _databaseContext.SaveChanges();

            return userSaved;
        }

        public User ValidateUser(string username)
        {
            var userFound = _databaseContext.Users.FirstOrDefault(x => x.Username == username);
            return userFound;
        }
    }
}
