using Motto.MR.Shared.Models;

namespace Motto.MR.Security
{
    public static class Login
    {
        public static User ValidateCredentials(User user)
        {
            var userRet = StaticUsers.Users.FirstOrDefault(u =>
            u.UserName == user.UserName && u.Password == user.Password);

            if (userRet == null)
            {
                userRet = user;
                userRet.SetIsAutenticated(false);
            }
            else
            {
                userRet.SetIsAutenticated(true);
            }

            return userRet;
        }
    }

    public static class StaticUsers
    {
        public static List<User> Users = new List<User>
        {
            new User ("admin", "admin123", "Admin"),
            new User ( "delivery", "delivery123", "Delivery" )
        };
    }
}
