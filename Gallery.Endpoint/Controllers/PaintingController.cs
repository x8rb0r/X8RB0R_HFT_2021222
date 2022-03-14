using Gallery.Data.Models;
using Gallery.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaintingController : ControllerBase
    {

        IPaintingLogic logic;

        public PaintingController(IPaintingLogic logic)
        {
            this.logic = logic;
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
        }
        [HttpPut]
        public void Update([FromBody] Painting value)
        {
            this.logic.UpdatePainting(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeletePainting(id);
        }
    }
}
