using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingApp.Entities
{
    public enum Role
    {
        User=0,
        Admin,
        

    }
    public class User :Base
    {
        public Role Role { get; set; }
        public List<Candidate> Candidates { get => candidates; set => candidates = value; }

        List<Candidate> candidates = new List<Candidate>();
    }
}
