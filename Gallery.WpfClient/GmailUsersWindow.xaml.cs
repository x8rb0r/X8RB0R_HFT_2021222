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
        RestService rest;
        public IList<Person> GmailUsers { get; set; }
        public GmailUsersWindow()
        {
            InitializeComponent();
            DataContext = this;

            rest = new RestService("http://localhost:26918/");
            CreateGmailUsersList();
        }
        public void CreateGmailUsersList()
        {
            GmailUsers = rest.Get<Person>("NonCRUD/GmailUsers");
        }
    }
}
