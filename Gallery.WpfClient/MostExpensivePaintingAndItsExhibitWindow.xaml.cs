using Gallery.Logic.Classes;
using Gallery.Logic.QueryGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gallery.WpfClient
{
    /// <summary>
    /// Interaction logic for MostExpensivePaintingAndItsExhibitWindow.xaml
    /// </summary>
    public partial class MostExpensivePaintingAndItsExhibitWindow : Window
    {
        public IList<MostExpensivePaintingAndItsExhibitGroup> MostExpensivePaintingAndItsExhibit { get; set; }
        public MostExpensivePaintingAndItsExhibitWindow()
        {
            InitializeComponent();

            DataContext = this;
            CreateMostExpensivePaintingAndItsExhibit();
        }
        public void CreateMostExpensivePaintingAndItsExhibit()
        {
            Factory f = new Factory();
            PaintingLogic paintingLogic = f.PaintingL;
            ExhibitLogic exhibitLogic = f.ExhibitL;

            var q = (from t1 in paintingLogic.ReadAll()
                     join t2 in exhibitLogic.ReadAll() on t1.ExhibitId equals t2.ExhibitId
                     orderby t1.Value descending
                     select new MostExpensivePaintingAndItsExhibitGroup()
                     {
                         EXHIBIT = t2.Title,
                         PAINTING = t1.Title,
                     }).Take(1);
             MostExpensivePaintingAndItsExhibit = q.ToList();
        }

    }
}
