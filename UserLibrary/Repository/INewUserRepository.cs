using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace UserLibrary.Repository
{
    public  interface INewUserRepository
    {
        User AddUser(User user);
        
    }
}
