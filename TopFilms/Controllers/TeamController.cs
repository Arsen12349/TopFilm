using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IActorRepo _repository;
        private readonly IMapper _mapper;

        public TeamController(IActorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/team
        [HttpGet]
        public ActionResult<IEnumerable<DirectorReadDto>> GetAll()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<DirectorReadDto>>(commandItems));
        }

        //GET api/team/{id}
        [HttpGet("{id}", Name = "GetId")]
        public ActionResult<DirectorReadDto> GetId(int id)
        {
            var commandItem = _repository.GetId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<DirectorReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/team/{id}
        [HttpPost]
        public ActionResult<DirectorReadDto> Create(DirectorCreateDto teamCreateDto)
        {
            var commandModel = _mapper.Map<Actor>(teamCreateDto);
            _repository.Create(commandModel);
            _repository.SaveChanges();

            var teamReadDto = _mapper.Map<DirectorReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetId), new { Id = teamReadDto.Id }, teamReadDto);
        }

        //PUT api/team/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DirectorUpdateDto teamUpdateDto)
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(teamUpdateDto, commandModelFromRepo);

            _repository.Update(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/team/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<DirectorUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<DirectorUpdateDto>(commandModelFromRepo);
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

        //DELETE api/team/{id}
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
