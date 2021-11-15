using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Data;

namespace TopFilms.Controllers.v2
{
    public class BaseController<R, M, D> : Controller where R : IBaseRepo<M>
    {
        R _repository { get; set; }

        private readonly IMapper _mapper;


        public BaseController(R repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        protected ActionResult<IEnumerable<D>> GetAll()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<D>>(commandItems));
        }


        protected ActionResult<D> GetId(int id)
        {
            var commandItem = _repository.GetId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<D>(commandItem));
            }
            return NotFound();
        }


    }
}
