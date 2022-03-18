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
    /// Interaction logic for ExhibitsAndTheNumberofPaintingsItHasWindow.xaml
    /// </summary>
    public partial class ExhibitsAndTheNumberofPaintingsItHasWindow : Window
    {
        public IList<ExhibitsAndCountPaintingsGroup> ExhibitsAndTheNumberofPaintingsItHas { get; set; }
        public ExhibitsAndTheNumberofPaintingsItHasWindow()
        {
            InitializeComponent();

            DataContext = this;
            CreateExhibitsAndTheNumberofPaintingsItHasList();
        }
        public void CreateExhibitsAndTheNumberofPaintingsItHasList()
        {
            Factory f = new Factory();
            PaintingLogic paintingLogic = f.PaintingL;
            ExhibitLogic exhibitLogic = f.ExhibitL;


            var q = from t1 in paintingLogic.ReadAll()
                    join t2 in exhibitLogic.ReadAll() on t1.ExhibitId equals t2.ExhibitId
                    group t2 by t2.Title into g
                    select new ExhibitsAndCountPaintingsGroup()
                    {
                        EXHIBIT = g.Key,
                        NUMBER_OF_PAINTINGS = g.Count(),
                    };
            ExhibitsAndTheNumberofPaintingsItHas = q.ToList();
        }
    }
}
