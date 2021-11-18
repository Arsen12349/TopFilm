using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;
using NLog;

namespace TopFilms.Controllers
{
    [Route("api/director")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IDirectorRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DirectorController> _logger;
        public DirectorController(IDirectorRepo repository, IMapper mapper, ILogger<DirectorController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/director
        [HttpGet]
        public ActionResult<IEnumerable<DirectorReadDto>> GetAll()
        {
            var commandItems = _repository.GetAll();
            _logger.LogInformation("GetAll action");

            //logger.Info("User with ");
            return Ok(_mapper.Map<IEnumerable<DirectorReadDto>>(commandItems));                     
        }

        //GET api/director/{id}
        [HttpGet("{id}", Name = "GetDirectorId")]
        public ActionResult<DirectorReadDto> GetDirectorId(int id)
        {
            var commandItem = _repository.GetDirectorId(id);
            if (commandItem != null)
            {
                _logger.LogInformation("GetId action");
                return Ok(_mapper.Map<DirectorReadDto>(commandItem));
            }
            _logger.LogError("NotFound");
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

            return CreatedAtRoute(nameof(GetDirectorId), new { Id = directorReadDto.Id }, directorReadDto);
        }

        //PUT api/director/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DirectorUpdateDto directorUpdateDto)
        {
            var commandModelFromRepo = _repository.GetDirectorId(id);
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
            var commandModelFromRepo = _repository.GetDirectorId(id);
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
            var commandModelFromRepo = _repository.GetDirectorId(id);
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
