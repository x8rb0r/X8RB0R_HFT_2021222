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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gallery.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Painting_ButtonClick(object sender, RoutedEventArgs e)
        {
            PaintingWindow paintingWindow = new PaintingWindow();
            paintingWindow.Show();

        }

        private void Person_ButtonClick(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            personWindow.Show();
        }
        private void ExhibitButton_Click(object sender, RoutedEventArgs e)
        {
            ExhibitWindow exhibitWindow = new ExhibitWindow();
            exhibitWindow.Show();
        }
        private void GmailUsersButton_Click(object sender, RoutedEventArgs e)
        {
            GmailUsersWindow w = new GmailUsersWindow();
            w.Show();
        }
        private void TopThreePaintingsButton_Click(object sender, RoutedEventArgs e)
        {
            TopThreePaintingsWindow w = new TopThreePaintingsWindow();
            w.Show();
        }

        private void CountNumberOfPaintingsButton_Click(object sender, RoutedEventArgs e)
        {
            CountNumberOfPaintingsMessageBox mb = new CountNumberOfPaintingsMessageBox();
            mb.DisplayMessageBox();
        }
    }
}
