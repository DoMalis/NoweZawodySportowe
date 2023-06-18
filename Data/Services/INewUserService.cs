using ProjektZawody.Models;

namespace ProjektZawody.Data.Services
{
    public interface INewUserService
    {
        void AddUser(NewUser newUser);
        List<UserModel> GetAllUsers();

    }
}
