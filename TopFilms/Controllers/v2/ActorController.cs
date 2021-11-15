using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.DTOs.ActorDTO;
using TopFilms.Models;

namespace TopFilms.Controllers.v2
{
    [Route("api/v2/actor")]
    [ApiController]
    public class ActorController : BaseController<IActorRepo, Actor, ActorDto>
    {
        
        public ActorController(IActorRepo repository, IMapper mapper) : base(repository, mapper) { }
        
        //GET api/actor
        [HttpGet]
        public new ActionResult<IEnumerable<ActorDto>> GetAll()
        {
            return base.GetAll();
        }

        //GET api/actor/{id}
        [HttpGet("{id}", Name = "GetId")]
        public new ActionResult<ActorDto> GetId(int id)
        {
            return base.GetId(id);
        }

    }
}
