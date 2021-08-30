using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Controllers
{
    [Route("api/director")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepo _repository;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/director
        [HttpGet]
        public ActionResult<IEnumerable<DirectorReadDto>> GetAll()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<DirectorReadDto>>(commandItems));
        }

        //GET api/director/{id}
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

        //POST api/director/{id}
        [HttpPost]
        public ActionResult<DirectorReadDto> Create(DirectorCreateDto directorCreateDto)
        {
            var commandModel = _mapper.Map<Director>(directorCreateDto);
            _repository.Create(commandModel);
            _repository.SaveChanges();

            var directorReadDto = _mapper.Map<DirectorReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetId), new { Id = directorReadDto.Id }, directorReadDto);
        }

        //PUT api/director/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DirectorUpdateDto directorUpdateDto)
        {
            var commandModelFromRepo = _repository.GetId(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(directorUpdateDto, commandModelFromRepo);

            _repository.Update(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/director/{id}
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

        //DELETE api/director/{id}
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
