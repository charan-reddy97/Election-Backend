//using Microsoft.EntityFrameworkCore;
//using Moq;
//using NUnit.Framework;
//using VotingApp;
//using VotingApp.Entities;
//using VotingApp.Repository;

//namespace VoterRepositoryTest
//{
//    public class VoterRepositoryTest
//    {
       
//        [Test]
//        public void AddUser_returns_User()
//        {
//            var options = new DbContextOptionsBuilder<VotingDbContext>().UseSqlServer("Integrated Security=False;Server=.\\SqlExpress;uid=sa;password=pass@123;database=Voting_DataBase3").Options; ;
//            var dbContext = new VotingDbContext(options);
//            UserRepository userRepository = new UserRepository(dbContext);

//            User user = new User();
//            user.FirstName = "Test";
//            user.Email = "Test@gmail.com";

//            var newuser = userRepository.AddUser(user);

//            Assert.IsNotNull(newuser);
//            Assert.IsTrue(newuser.Id > 0);


//        }
//        [Test]
//        public void Delete_user()
//        {
//            var options = new DbContextOptionsBuilder<VotingDbContext>().UseSqlServer("Integrated Security=False;Server=.\\SqlExpress;uid=sa;password=pass@123;database=Voting_DataBase3").Options; ;
//            var dbContext = new VotingDbContext(options);
//            UserRepository userRepository = new UserRepository(dbContext);
//            User user = new User();
//            user.Id = 0;
//            userRepository.DeleteUser(1);

//            Assert.IsTrue(user.DeletedDate == null);
//            //Assert.IsTrue(user.DeletedDate != null);


//        }
//        [Test]
//        public void FindByUserName_Return_User()
//        {
//            var options = new DbContextOptionsBuilder<VotingDbContext>().UseSqlServer("Integrated Security=False;Server=.\\SqlExpress;uid=sa;password=pass@123;database=Voting_DataBase3").Options; ;
//            var dbContext = new VotingDbContext(options);
//            UserRepository userRepository = new UserRepository(dbContext);
//            //User user = new User();
//            //user.Email = "test@gmail.com";
//            //user.Password = "12345";
//            var newuser = userRepository.FindByUserName("Test@gmail.com", "12345");
//            Assert.IsNotNull(newuser!=null);
//        }
//        [Test]
//        public void GetUsers_returns_all_Users()
//        {
//            var options = new DbContextOptionsBuilder<VotingDbContext>().UseSqlServer("Integrated Security=False;Server=.\\SqlExpress;uid=sa;password=pass@123;database=Voting_DataBase3").Options; ;
//            var dbContext = new VotingDbContext(options);
//            UserRepository userRepository = new UserRepository(dbContext);
//            var users = userRepository.GetUsers();

//            Assert.That(users.Count > 0);


//        }
//        [Test]
//        public void Update_user_return_user()
//        {
//            var options = new DbContextOptionsBuilder<VotingDbContext>().UseSqlServer("Integrated Security=False;Server=.\\SqlExpress;uid=sa;password=pass@123;database=Voting_DataBase3").Options; ;
//            var dbContext = new VotingDbContext(options);
//            UserRepository userRepository = new UserRepository(dbContext);
//            User user = new User();
//            user.Id = 1;
//            var users = userRepository.UpdateUser(user);

//            Assert.IsNotNull(users);
//        }
//    }
//}