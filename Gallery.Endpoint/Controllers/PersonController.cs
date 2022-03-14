using Gallery.Data.Models;
using Gallery.Logic;
using Gallery.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        IPersonLogic logic;

        public PersonController(IPersonLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Person> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Person Read(int id)
        {
            return this.logic.GetPersonById(id);
        }

        [HttpPost]
        public void Create([FromBody] Person value)
        {
            this.logic.AddPerson(value);
        }

        [HttpPut]
        public void Update([FromBody] Person value)
        {
            this.logic.UpdatePerson(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeletePerson(id);
        }
    }
}
