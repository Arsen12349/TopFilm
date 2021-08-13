using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ITopFilmsRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ITopFilmsRepo repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<FilmsReadDto>> GetAllCommands() 
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<FilmsReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <FilmsReadDto> GetCommandById(int id) 
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null) 
            {
                return Ok(_mapper.Map<FilmsReadDto>(commandItem));
            }
            return NotFound();
        }
    }
}
