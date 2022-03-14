using Gallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.WpfClient
{
    class MainWindowViewModel
    {
       public RestCollection<Painting> Paintings { get; set; }
        public MainWindowViewModel()
        {

        }
    }
}
