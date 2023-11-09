using Prueba.Model.AggregateModels;
using Prueba.Model.Dtos;

namespace Prueba.Api.Services
{
    public interface IUserAccountService
    {
        Person CreateUser(UserDataDto userData);
        Person LoginUser(LoginRequestDto loginData);
        Person GetUserById(int id);
    }
}
