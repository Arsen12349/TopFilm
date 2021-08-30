using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Controllers
{  
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepo _repository;
        private readonly IMapper _mapper;

        public FilmsController(IFilmRepo repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/films
        [HttpGet]
        public ActionResult <IEnumerable<FilmReadDto>> GetAll() 
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<FilmReadDto>>(commandItems));
        }

        //GET api/films/{id}
        [HttpGet("{id}", Name = "GetFilmId")]
        public ActionResult <FilmReadDto> GetFilmId(int id) 
        {
            var commandItem = _repository.GetFilmId(id);
            if(commandItem != null) 
            {
                return Ok(_mapper.Map<FilmReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/films/{id}
        [HttpPost]
        public ActionResult <FilmReadDto> Create(FilmCreateDto filmsCreateDto) 
        {
            var commandModel = _mapper.Map<Film>(filmsCreateDto);
            _repository.Create(commandModel);
            _repository.SaveChanges();

            var filmsReadDto = _mapper.Map<FilmReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetFilmId), new { Id = filmsReadDto.Id }, filmsReadDto);
        }

        //PUT api/films/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, FilmUpdateDto filmsUpdateDto) 
        {
            var commandModelFromRepo = _repository.GetFilmId(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }
            _mapper.Map(filmsUpdateDto, commandModelFromRepo);

            _repository.Update(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/films/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<FilmUpdateDto> patchDoc) 
        {
            var commandModelFromRepo = _repository.GetFilmId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<FilmUpdateDto>(commandModelFromRepo);
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

        //DELETE api/films/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var commandModelFromRepo = _repository.GetFilmId(id);
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
