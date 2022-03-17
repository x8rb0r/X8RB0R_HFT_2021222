using Gallery.Data;
using Gallery.Data.Models;
using Gallery.Logic;
using Gallery.Repository;
using System;
using System.Collections;
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
    /// Interaction logic for GmailUsersWindow.xaml
    /// </summary>
    public partial class GmailUsersWindow : Window
    {
        public IList<Person> GmailUsers { get; set; }
        public GmailUsersWindow()
        {
            InitializeComponent();
            DataContext = this;
            CreateGmailUsersList();
        }
        public void CreateGmailUsersList()
        {
            GalleryContext ctx = new GalleryContext();
            //ExhibitRepository exhibitRepo = new ExhibitRepository(ctx);
            PersonRepository personRepo = new PersonRepository(ctx);
            //PaintingRepository paintingRepo = new PaintingRepository(ctx);
            PersonLogic l = new PersonLogic(personRepo);

            GmailUsers = l.GmailUsers();

        }
    }
}
