using Gallery.Data;
using Gallery.Data.Models;
using Gallery.Logic.Classes;
using Gallery.Repository;
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
    /// Interaction logic for TopThreePaintingsWindow.xaml
    /// </summary>
    public partial class TopThreePaintingsWindow : Window
    {
        public IList<Painting> TopThreePaintings { get; set; }
        public TopThreePaintingsWindow()
        {
            InitializeComponent();
            DataContext = this;

            CreateTopThreePaintingsList();
        }

        public void CreateTopThreePaintingsList()
        {

            Factory f = new Factory();
            TopThreePaintings = f.PaintingL.TopThreeMostExpensivePaintings();
            

        }
    }
}

