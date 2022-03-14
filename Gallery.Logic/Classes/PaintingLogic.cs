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
    public class PaintingLogic : IPaintingLogic
    {
        private readonly IPaintingRepository paintingRepo;
        public PaintingLogic(IPaintingRepository repo)
        {
            this.paintingRepo = repo;
        }

        public void AddPainting(Painting newPainting)
        {
            this.paintingRepo.AddPainting(newPainting);
        }

        public void DeletePainting(int id)
        {
            this.paintingRepo.DeletePainting(id);
        }

        public IQueryable<Painting> ReadAll()
        {
            return this.paintingRepo.GetAll();
        }

        public Painting GetPainting(int id)
        {
            return this.paintingRepo.GetOne(id);
        }

        public bool PaintingExists(int id)
        {
            return this.paintingRepo.Exists(id);
        }


        public void UpdatePainting(Painting newP)
        {
            this.paintingRepo.UpdatePainting(newP);
        }
    }
}
