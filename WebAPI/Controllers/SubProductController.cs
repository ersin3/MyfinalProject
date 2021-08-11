using AutoMapper;
using Business.Abstract;
using Entities.WiewModel.Entities.WiewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProductController: ControllerBase
    {
        
        ISubProductService _subproductservice;
        IMapper _mapper;
        public SubProductController(ISubProductService subproductService,IMapper mapper)
        {
            _subproductservice = subproductService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            // bağımlılık zinciri

            var result = _subproductservice.GetAll();
          //  var viewModel = _mapper.Map<SubProductViewModel>(result.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Data);
            }

        }

     

    }
}
