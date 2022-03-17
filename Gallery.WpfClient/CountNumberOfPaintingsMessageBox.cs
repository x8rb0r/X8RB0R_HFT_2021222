using Gallery.Data;
using Gallery.Logic.Classes;
using Gallery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gallery.WpfClient
{
    class CountNumberOfPaintingsMessageBox
    {
        private static GalleryContext Ctx = new GalleryContext();
        private static PaintingRepository PaintingRepo = new PaintingRepository(Ctx);
        private static PaintingLogic l = new PaintingLogic(PaintingRepo);

        public void DisplayMessageBox()
        {
            MessageBox.Show("Number of paintings: " + l.NumberOfPaintings().ToString());
        }
    }
}
