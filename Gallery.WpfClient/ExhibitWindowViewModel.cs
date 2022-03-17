using Gallery.Data.Models;
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

namespace Gallery.WpfClient
{
    class ExhibitWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Exhibit> Exhibits { get; set; }

        private Exhibit selectedExhibit;
        public Exhibit SelectedExhibit
        {
            get { return selectedExhibit; }
            set
            {
                if (value != null)
                {
                    selectedExhibit = new Exhibit()
                    {
                        ExhibitId = value.ExhibitId,
                        Title = value.Title,
                        Start = value.Start,
                        End = value.End,
                        Rating = value.Rating,
                        EntryFee= value.EntryFee
                    };
                    OnPropertyChanged();
                    (DeleteExhibitCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateExhibitCommand { get; set; }
        public ICommand DeleteExhibitCommand { get; set; }
        public ICommand UpdateExhibitCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ExhibitWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Exhibits = new RestCollection<Exhibit>("http://localhost:26918/", "exhibit", "hub");
                CreateExhibitCommand = new RelayCommand(() =>
                {
                    Exhibits.Add(new Exhibit()
                    {
                        Title = selectedExhibit.Title,
                        Start = selectedExhibit.Start,
                        End = selectedExhibit.End,
                        Rating = selectedExhibit.Rating,
                        EntryFee = selectedExhibit.EntryFee

                    });
                });

                UpdateExhibitCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Exhibits.Update(SelectedExhibit);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteExhibitCommand = new RelayCommand(() =>
                {
                    Exhibits.Delete(SelectedExhibit.ExhibitId);

                },
                () =>
                {
                    return SelectedExhibit != null;
                }


                );
                SelectedExhibit = new Exhibit();
            }

        }
    }
}
