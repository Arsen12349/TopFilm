using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Data;
using TopFilms.DTOs;

namespace TopFilms.Controllers
{
    [Route("api/two")]
    [ApiController]
    public class TwoController<T, D, R> : BaseController<T, D, R>
    {
        private readonly IBaseRepo _repository;
        private readonly IMapper _mapper;

        public TwoController(IBaseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/one/{id}
        [HttpGet("{id}", Name = "GetBaseId")]
        public ActionResult<BaseDto> GetBaseId(int id)
        {
            var commandItem = _repository.GetBaseId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<BaseDto>(commandItem));
            }
            return NotFound();
        }
    }
}
