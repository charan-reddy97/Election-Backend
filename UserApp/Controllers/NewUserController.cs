using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingApp.Repository;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewUserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public NewUserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = userRepository.AddUser(user);
            return Created($"/api/election/{user.Id}", user);
        }
    }
}
