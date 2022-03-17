using Gallery.Data.Models;
using Gallery.Endpoint.Services;
using Gallery.Logic;
using Gallery.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;


namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IHubContext<SignalRHub> hub;
        IPersonLogic logic;

        public PersonController(IPersonLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PersonCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Person value)
        {
            this.logic.UpdatePerson(value);
            this.hub.Clients.All.SendAsync("PersonUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var personToDelete = this.logic.GetPersonById(id);
            this.logic.DeletePerson(id);
            this.hub.Clients.All.SendAsync("PersonDeleted", personToDelete);
        }
    }
}
