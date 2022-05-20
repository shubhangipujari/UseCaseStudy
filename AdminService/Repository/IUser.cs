using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Repository
{
    public interface IUser
    {
        IEnumerable<UserDetail> GetUsers();
        UserDetail GetUserById(int userId);
        void CreateUser(UserDetail user);
        void DeleteUser(int userId);
        void UpdateUser(UserDetail user);

        Object Login(string emailId, string password);
        void Save();


    }
}
