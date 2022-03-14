using Gallery.Data.Models;
using Gallery.Logic.Interfaces;
using Gallery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Logic.Classes
{
    public class ExhibitLogic : IExhibitLogic
    {
        private readonly IExhibitRepository exhibitRepo;
        public ExhibitLogic(IExhibitRepository repo)
        {
            this.exhibitRepo = repo;
        }
        public void AddExhibit(Exhibit newExhibit)
        {
            this.exhibitRepo.AddExhibit(newExhibit);
        }

        public void DeleteExhibit(int id)
        {
            this.exhibitRepo.DeleteExhibit(id);
        }

        public bool ExhibitExists(int id)
        {
            return this.exhibitRepo.Exists(id);
        }

        /* public IList<Exhibit> GetAllExhibits()
         {
             return this.exhibitRepo.GetAll().ToList();
         }*/

        public IQueryable<Exhibit> ReadAll()
        {
            return this.exhibitRepo.GetAll();
        }

            public Exhibit GetExhibit(int id)
        {
            return this.exhibitRepo.GetOne(id);
        }

        public void UpdateExhibit(Exhibit newX)
        {
            this.exhibitRepo.UpdateExhibit(newX);
        }

    }
}
