using EFPostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPostgreSQL.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(string name, int age);
        Task UpdateAsync(int id, string name, int age);
        Task DeleteAsync(int id);
    }
}
