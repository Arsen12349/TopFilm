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
    [Route("api/one")]
    [ApiController]
    public class OneController<T, D, R> : BaseController <T, D, R>
    {
        private readonly IBaseRepo _repository;
        private readonly IMapper _mapper;

        public OneController(IBaseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/one
        [HttpGet]
        public ActionResult<IEnumerable<BaseDto>> GetAll()
        {
            var T_Item = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<BaseDto>>(T_Item));
        }

    }
}
