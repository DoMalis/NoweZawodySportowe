using ProjektZawody.Models;

namespace ProjektZawody.Data.Services
{
    public interface INewUserService
    {
        void AddUser(NewUser newUser);
        List<UserModel> GetAllUsers();
        void DeleteUser(int id);
        UserModel GetUserById(int id);

    }
}
