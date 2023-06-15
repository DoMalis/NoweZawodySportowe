﻿using ProjektZawody.Models;

namespace ProjektZawody.Services
{
    public class SecurityService
    {
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
