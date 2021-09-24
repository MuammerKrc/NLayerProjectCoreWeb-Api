using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonController(IService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var person = await _personService.GetAllAsync();
            return Ok(person);
        }
        [HttpPut]
        public async Task<IActionResult> Create(Person person)
        {
            var result = await _personService.AddASync(person);
            return Created(string.Empty, result);
        }
    }
}
