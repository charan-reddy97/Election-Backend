using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VotingLibrary.Entities;

namespace VotingApp.Entities
{
    public class Candidate:Base
    {
        
        public string Address { get; set; }  
        public string Photo { get; set; }
       
    }
}
