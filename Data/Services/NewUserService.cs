using Microsoft.EntityFrameworkCore;
using ProjektZawody.Models;
using ProjektZawody.Services;
using System.Numerics;

namespace ProjektZawody.Data.Services
{
    public class NewUserService : INewUserService
    {
        private readonly UserDAO usersDAO;
        public NewUserService(UserDAO usersDAO)
        {
            this.usersDAO = usersDAO;
        }

        public void AddUser(NewUser user)
        {
            usersDAO.AddUser(user);
        }


        public List<UserModel> GetAllUsers()
        {
            var result = usersDAO.GetAllUsers();
            return result;
        }

        public void DeleteUser(int id)
        {
            usersDAO.DeleteUser(id);
        }

        public UserModel GetUserById(int id) 
        {
            var result = usersDAO.GetUser(id);
            return result;
        }


    }
}
