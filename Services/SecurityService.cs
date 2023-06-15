using ProjektZawody.Models;

namespace ProjektZawody.Services
{
    public class SecurityService
    {
        List<UserModel> knownUsers = new List<UserModel>();
        UserDAO usersDAO = new UserDAO();
        public SecurityService() 
        {

        }

        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
