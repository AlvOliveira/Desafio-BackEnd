
namespace Motto.MR.Shared.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; private set; }
        public bool IsAutenticated { get; private set; }

        // Construtor para inicializar as propriedades
        public User() { }

        public User(string userName, string password) 
        {
            UserName = userName;
            Password = password;
        }

        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public void SetIsAutenticated(bool isAutenticated)
        {
            this.IsAutenticated = isAutenticated;
        }

        public void SetRole(string role)
        {
            this.Role = role;
        }
    }
}
