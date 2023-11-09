using Prueba.Model.AggregateModels;

namespace Prueba.Data.Repositories.PersonRepository
{
    public interface IPersonRepository
    {
        Person Add(Person person);
        Person GetPersonByUserId(int userId);
        Person GetPersonById(int id);
    }
}
