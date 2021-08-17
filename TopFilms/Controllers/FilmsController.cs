using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Controllers
{  
    [Route("api/commands")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ITopFilmsRepo _repository;
        private readonly IMapper _mapper;

        public FilmsController(ITopFilmsRepo repository, IMapper mapper) 
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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <FilmsReadDto> GetCommandById(int id) 
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null) 
            {
                return Ok(_mapper.Map<FilmsReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands/{id}
        [HttpPost]
        public ActionResult <FilmsReadDto> CreateCommand(FilmsCreateDto filmsCreateDto) 
        {
            var commandModel = _mapper.Map<Films>(filmsCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var filmsReadDto = _mapper.Map<FilmsReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = filmsReadDto.Id }, filmsReadDto);
            //return Ok(filmsReadDto);
        }


    }
}
