using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingApp.Entities
{
    public class UserModel :Base
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
