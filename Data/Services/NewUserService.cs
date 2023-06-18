using Microsoft.EntityFrameworkCore;
using ProjektZawody.Models;
using System.Numerics;

namespace ProjektZawody.Data.Services
{
    public class NewUserService : INewUserService
    {
        private readonly AppDbContext _context;

        public NewUserService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(NewUser newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }
    }
}
