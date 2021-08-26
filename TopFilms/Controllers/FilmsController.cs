using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IFilmsRepo _repository;
        private readonly IMapper _mapper;

        public FilmsController(IFilmsRepo repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<FilmsReadDto>> GetAll() 
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<FilmsReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetId")]
        public ActionResult <FilmsReadDto> GetId(int id) 
        {
            var commandItem = _repository.GetId(id);
            if(commandItem != null) 
            {
                return Ok(_mapper.Map<FilmsReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands/{id}
        [HttpPost]
        public ActionResult <FilmsReadDto> Create(FilmsCreateDto filmsCreateDto) 
        {
            var commandModel = _mapper.Map<Films>(filmsCreateDto);
            _repository.Create(commandModel);
            _repository.SaveChanges();

            var filmsReadDto = _mapper.Map<FilmsReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetId), new { Id = filmsReadDto.Id }, filmsReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, FilmsUpdateDto filmsUpdateDto) 
        {
            var commandModelFromRepo = _repository.GetId(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }
            _mapper.Map(filmsUpdateDto, commandModelFromRepo);

            _repository.Update(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<FilmsUpdateDto> patchDoc) 
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<FilmsUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) 
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.Update(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.Delete(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}
