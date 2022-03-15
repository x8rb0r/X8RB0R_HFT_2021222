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
    public class PaintingController : ControllerBase
    {
        IHubContext<SignalRHub> hub;
        IPaintingLogic logic;

        public PaintingController(IPaintingLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Painting> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Painting Read(int id)
        {
            return this.logic.GetPainting(id);
        }

        [HttpPost]
        public void Create([FromBody] Painting value)
        {
            this.logic.AddPainting(value);
            this.hub.Clients.All.SendAsync("PaintingCreated", value);
        }
        [HttpPut]
        public void Update([FromBody] Painting value)
        {
            this.logic.UpdatePainting(value);
            this.hub.Clients.All.SendAsync("PaintingUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var paintingToDelete = this.logic.GetPainting(id);
            this.logic.DeletePainting(id);
            this.hub.Clients.All.SendAsync("PaintingDeleted", paintingToDelete);
        }
    }
}
