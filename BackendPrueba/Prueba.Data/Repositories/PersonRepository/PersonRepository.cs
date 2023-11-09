using Prueba.Model.AggregateModels;

namespace Prueba.Data.Repositories.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _databaseContext;
        public PersonRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public Person Add(Person person)
        {
            var personSaved = _databaseContext.Persons.Add(person).Entity;
            _databaseContext.SaveChanges();

            return personSaved;      
        }

        public Person GetPersonById(int id)
        {
            var person = _databaseContext.Persons.FirstOrDefault(x => x.Id == id);
            return person;
        }

        public Person GetPersonByUserId(int userId)
        {
            var person = _databaseContext.Persons.FirstOrDefault(x => x.User.Id == userId);
            return person;
        }
    }
}
