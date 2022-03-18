using Gallery.Data;
using Gallery.Logic;
using Gallery.Logic.Classes;
using Gallery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.WpfClient
{
    public class Factory
    {
        public PersonLogic PersonL { get; set; }

   
        public PaintingLogic PaintingL { get; set; }
        public ExhibitLogic ExhibitL { get; set; }

        private static GalleryContext ctx = new GalleryContext();
        private static ExhibitRepository exhibitRepo = new ExhibitRepository(ctx);
        private static PersonRepository personRepo = new PersonRepository(ctx);
        private static PaintingRepository paintingRepo = new PaintingRepository(ctx);

        public Factory()
        {
            this.PersonL = new PersonLogic(personRepo);
            this.PaintingL = new PaintingLogic(paintingRepo);
            this.ExhibitL = new ExhibitLogic(exhibitRepo);
        }
        
    }
}
