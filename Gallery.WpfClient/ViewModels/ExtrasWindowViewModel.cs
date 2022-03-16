using Gallery.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gallery.WpfClient.ViewModels
{
    class ExtrasWindowViewModel : ObservableRecipient
    {
        public ICommand ListGmailCommand { get; set; }
        public ICommand CountPaintingsCommand { get; set; }
        public ICommand ListTopThreeExpensivePaintingsCommand { get; set; }
        public ICommand ListFreeExhibitsCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ExtrasWindowViewModel()
        {
            /*IPersonRepo personRepo
            PersonLogic personLogic = new PersonLogic();
            if (!IsInDesignMode)
            {
                
                ListGmailCommand = new RelayCommand(() =>
                {
                    
                });
            }*/
        }
    }
}
