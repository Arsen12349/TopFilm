using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopFilms.Data;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Controllers.v2
{
    [Route("api/director")]
    [ApiController]
    public class DirectorController : BaseController<IDirectorRepo, Director, DirectorReadDto>
    {
      
        public DirectorController(IDirectorRepo repository, IMapper mapper) : base(repository, mapper)
        {

        }

        //GET api/director
        [HttpGet]
        public new ActionResult<IEnumerable<DirectorReadDto>> GetAll()
        {
            return base.GetAll();
        }

        //GET api/director/{id}
        [HttpGet("{id}", Name = "GetId")]
        public new  ActionResult<DirectorReadDto> GetId(int id)
        {
            return base.GetId(id);
        }
    }
}
