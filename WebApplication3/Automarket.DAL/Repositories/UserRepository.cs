using Itmytask.DAL.Interfaces;
using Itmytask.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itmytask.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)  // инициализировали класс в конструкторе
        {
            _db = db;
        }

        public async Task<bool> Create(Users entity)
        {
            await _db.User.AddAsync(entity);

            await _db.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Users>> GetAsyncSelect()
        {
            throw new NotImplementedException();
        }

        public async Task<Users> GetByNameAsyncU(string name)
        {
            // return await _db.Work.FirstOrDefaultAsync(x => x.Name == name);
            return await _db.User.FirstOrDefaultAsync(x => x.Name == name);
        }




        public async Task<List<Users>> Select()
        {

            List<Users> users = await _db.User.ToListAsync();
            return users;
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
