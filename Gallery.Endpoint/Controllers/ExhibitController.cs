using Gallery.Data.Models;
using Gallery.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExhibitController : ControllerBase
    {

        IExhibitLogic logic;

        public ExhibitController(IExhibitLogic logic)
        {
            this.logic = logic;
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
        }
        [HttpPut]
        public void Update([FromBody] Exhibit value)
        {
            this.logic.UpdateExhibit(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteExhibit(id);
        }
    }
}
