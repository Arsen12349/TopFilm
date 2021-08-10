using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Data;
using TopFilms.Models;

namespace TopFilms.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ITopFilmsRepo _repository;

        public CommandsController(ITopFilmsRepo repository) 
        {
            _repository = repository;
        }

        
      
        //private readonly MockTopFilmsRepo _repository = new MockTopFilmsRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Films>> GetAllCommands() 
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Films> GetCommandById(int id) 
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}
