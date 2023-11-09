using Prueba.Data.Repositories.PersonRepository;
using Prueba.Data.Repositories.UserRepository;
using Prueba.Model.AggregateModels;
using Prueba.Model.Dtos;

namespace Prueba.Api.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUserRepository _userRepository;

        public UserAccountService(IPersonRepository personRepository, IUserRepository userRepository)
        {
            _personRepository = personRepository;
            _userRepository = userRepository;
        }

        public Person CreateUser(UserDataDto userData)
        {
            var newUser = new User(userData.Username, userData.Pass);
            var userCreated = _userRepository.Add(newUser);

            var newPerson = new Person(userData.Name, userData.LastName, userData.NumIdentification, userData.Email, userData.IdentificationType, userCreated.Id);
            var personCreated = _personRepository.Add(newPerson);

            return personCreated;
        }

        public Person LoginUser(LoginRequestDto loginData)
        {
            var userFound = _userRepository.ValidateUser(loginData.Username);

            if (userFound == null || userFound.Pass != loginData.Pass)
            {
                return null;
            }

            var userData = _personRepository.GetPersonByUserId(userFound!.Id);
            return userData;
        }

        public Person GetUserById(int id)
        {
            var userFound = _personRepository.GetPersonById(id);

            if (userFound == null)
            {
                return null;
            }

            var userData = _personRepository.GetPersonByUserId(userFound!.Id);
            return userData;
        }
    }
}
