using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Model.AggregateModels
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NumIdentification { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public DateTime CreatedDate { get; set; }

        public string IdentificationAndType { get; }
        public string FullName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Person() { }

        public Person(string name, string lastname, string numIdentification, string email, string identificationType, int userId)
        {
            Name = name;
            LastName = lastname;
            NumIdentification = numIdentification;
            Email = email;
            IdentificationType = identificationType;
            UserId = userId;
        }
    }
}
