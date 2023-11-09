using System.Security.Principal;

namespace Prueba.Model.AggregateModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public DateTime CreatedDate { get; set; }

        public Person Person;

        public User() { }

        public User(string username, string pass)
        {
            Username = username;
            Pass = pass;
        }
    }
}
