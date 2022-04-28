using Gallery.Data.Models;
using Gallery.Logic;
using Gallery.Logic.Interfaces;
using Gallery.Logic.QueryGroups;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gallery.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCRUDController : ControllerBase
    {
        IExhibitLogic exhibitLogic;
        IPaintingLogic paintingLogic;
        IPersonLogic personLogic;

        public NonCRUDController(IExhibitLogic exhibitLogic, IPaintingLogic paintingLogic, IPersonLogic personLogic)
        {
            this.exhibitLogic = exhibitLogic;
            this.paintingLogic = paintingLogic;
            this.personLogic = personLogic;

        }

        [HttpGet]
        public IEnumerable<MostExpensivePaintingAndItsExhibitGroup> MostExpensivePaintingandItsExhibit()
        {
            var q = (from t1 in paintingLogic.ReadAll()
                     join t2 in exhibitLogic.ReadAll() on t1.ExhibitId equals t2.ExhibitId
                     orderby t1.Value descending
                     select new MostExpensivePaintingAndItsExhibitGroup()
                     {
                         EXHIBIT = t2.Title,
                         PAINTING = t1.Title,
                     }).Take(1);
            return q;
        }

        [HttpGet]
        public IEnumerable<Person> GmailUsers()
        {
            var q = from x in this.personLogic.ReadAll()
                    where x.Email.Contains("@gmail.com")
                    select x;
            return q;
        }

        [HttpGet]
        public IEnumerable<ExhibitsAndCountPaintingsGroup> ExhibitsCountPaintings()
        {
            var q = from t1 in paintingLogic.ReadAll()
                    join t2 in exhibitLogic.ReadAll() on t1.ExhibitId equals t2.ExhibitId
                    group t2 by t2.Title into g
                    select new ExhibitsAndCountPaintingsGroup()
                    {
                        EXHIBIT = g.Key,
                        NUMBER_OF_PAINTINGS = g.Count(),
                    };
            return q;
        }



    }
}
