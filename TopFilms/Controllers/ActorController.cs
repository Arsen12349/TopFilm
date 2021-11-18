using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.DTOs.ActorDTO;
using TopFilms.Models;

namespace TopFilms.Controllers
{
    [Route("api/actor")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepo _repository;
        private readonly IMapper _mapper;

        public ActorController(IActorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/actor
        [HttpGet]
        public ActionResult<IEnumerable<ActorDto>> GetAll()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ActorDto>>(commandItems));
        }

        //GET api/actor/{id}
        [HttpGet("{id}", Name = "GetId")]
        public ActionResult<ActorDto> GetId(int id)
        {
            var commandItem = _repository.GetId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ActorDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/actor/{id}
        [HttpPost]
        public ActionResult<ActorDto> Create(ActorDto actorCreateDto)
        {
            var commandModel = _mapper.Map<Actor>(actorCreateDto);
            _repository.Create(commandModel);
            _repository.SaveChanges();

            var actorReadDto = _mapper.Map<ActorDto>(commandModel);

            return CreatedAtRoute(nameof(GetId), new { Id = actorReadDto.Id }, actorReadDto);
        }

        //PUT api/actor/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, ActorDto actorUpdateDto)
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(actorUpdateDto, commandModelFromRepo);

            _repository.Update(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/actor/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<ActorDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<ActorDto>(commandModelFromRepo);
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

        //DELETE api/actor/{id}
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
