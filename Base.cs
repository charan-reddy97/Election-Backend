using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingApp.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
   
        public string Gender { get; set; }
      
        public DateTime DOB { get; set; }
   
        public string Email { get; set; }
     
        public string Password { get; set; }
        public int Aadhar { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
