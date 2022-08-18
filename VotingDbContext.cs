using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingLibrary.Entities;

namespace VotingApp
{
    public class VotingDbContext :DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Integrated Security=False;Server=.\\SqlExpress;uid=sa;password=pass@123;database=VotingDb");
        //}
    }
}
