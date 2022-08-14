using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp;
using VotingApp.Entities;

namespace UserLibrary.Repository
{
    public class NewUserRepository:INewUserRepository
    {
        VotingDbContext dbContext;

      

        public NewUserRepository(VotingDbContext dbContext)
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
    }
}
