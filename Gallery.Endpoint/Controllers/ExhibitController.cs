using Gallery.Data.Models;
using Gallery.Endpoint.Services;
using Gallery.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;


namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExhibitController : ControllerBase
    {
        IHubContext<SignalRHub> hub;
        IExhibitLogic logic;

        public ExhibitController(IExhibitLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Exhibit> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Exhibit Read(int id)
        {
            return this.logic.GetExhibit(id);
        }

        [HttpPost]
        public void Create([FromBody] Exhibit value)
        {
            this.logic.AddExhibit(value);
            this.hub.Clients.All.SendAsync("ExhibitCreated", value);
        }
        [HttpPut]
        public void Update([FromBody] Exhibit value)
        {
            this.logic.UpdateExhibit(value);
            this.hub.Clients.All.SendAsync("ExhibitUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var exhibitToDelete = this.logic.GetExhibit(id);
            this.logic.DeleteExhibit(id);
            this.hub.Clients.All.SendAsync("ExhibitDeleted", exhibitToDelete);
        }
    }
}
