using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingLibrary.Entities;
using VotingLibrary.Repository;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ElectionController : ControllerBase
    {
        private readonly IELectionRepository electionRepository;
        public ElectionController(IELectionRepository electionRepository)
        {
            this.electionRepository = electionRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var elections = electionRepository.GetElections();
            return Ok(elections);
        }
        [HttpGet("byname/{name}")]
        public IActionResult Get(string name)
        {
            var election = electionRepository.FindElectionByName(name);
            return Ok(election);
        }
        [HttpGet("byid/{id}")]
        public IActionResult Get(int id)
        {
            var election = electionRepository.FindElectionById(id);
            return Ok(election);
        }
      
      
            
    }
}
