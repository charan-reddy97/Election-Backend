using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        void DeleteUser(int userid);
        User FindByUserName(string username, string password);
        User FindById(int id);
        List<User> GetUsers();
        User UpdateUser(User user);
    }
}
