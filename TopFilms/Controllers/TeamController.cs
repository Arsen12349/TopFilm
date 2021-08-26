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
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepo _repository;
        private readonly IMapper _mapper;

        public TeamController(ITeamRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetAll()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<TeamReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetId")]
        public ActionResult<TeamReadDto> GetId(int id)
        {
            var commandItem = _repository.GetId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<TeamReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands/{id}
        [HttpPost]
        public ActionResult<TeamReadDto> Create(TeamCreateDto teamCreateDto)
        {
            var commandModel = _mapper.Map<Team>(teamCreateDto);
            _repository.Create(commandModel);
            _repository.SaveChanges();

            var teamReadDto = _mapper.Map<TeamReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetId), new { Id = teamReadDto.Id }, teamReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, TeamUpdateDto teamUpdateDto)
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

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<TeamUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<TeamUpdateDto>(commandModelFromRepo);
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
