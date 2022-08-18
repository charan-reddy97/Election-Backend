using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Repository
{
    public class UserRepository : IUserRepository
    {
        VotingDbContext dbContext;

        //public UserRepository()
        //{
        //}

        public UserRepository(VotingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public User AddUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(int userid)
        {
            User currentUser = dbContext.Users.FirstOrDefault(d => d.Id == userid);
            if (currentUser != null)
            {
                currentUser.DeletedDate = DateTime.Now;
                dbContext.Users.Update(currentUser);
                dbContext.SaveChanges();

            }
        }

        public User FindByUserName(string username, string password)
        {
            return dbContext.Users.FirstOrDefault(d => d.Email == username
                                                    && d.Password == password);
        }

        public List<User> GetUsers()
        {
            return dbContext.Users.Where(d => d.DeletedDate == null).ToList();
        }

        public User UpdateUser(User user)
        {
            User currentUser = dbContext.Users.FirstOrDefault(d => d.Id == user.Id);
            if (currentUser != null)
            {
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.Password = user.Password;
                currentUser.Role = user.Role;
                currentUser.Gender = user.Gender;
                currentUser.Aadhar = user.Aadhar;
                

                dbContext.Users.Update(currentUser);
                dbContext.SaveChanges();

            }

            return user;
        }
        public User FindById(int id)
        {
            return dbContext.Users.FirstOrDefault(d => d.Id == id);
        }
    }
}
