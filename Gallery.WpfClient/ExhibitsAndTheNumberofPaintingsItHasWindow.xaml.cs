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
        RestService rest;
        public IList<ExhibitsAndCountPaintingsGroup> ExhibitsAndTheNumberofPaintingsItHas { get; set; }
        public ExhibitsAndTheNumberofPaintingsItHasWindow()
        {
            InitializeComponent();

            DataContext = this;

            rest = new RestService("http://localhost:26918/");
            CreateExhibitsAndTheNumberofPaintingsItHasList();
        }
        public void CreateExhibitsAndTheNumberofPaintingsItHasList()
        {

            ExhibitsAndTheNumberofPaintingsItHas = rest.Get<ExhibitsAndCountPaintingsGroup>("NonCRUD/ExhibitsCountPaintings");

        }
    }
}
