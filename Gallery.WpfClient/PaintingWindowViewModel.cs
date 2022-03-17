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
    class PaintingWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Painting> Paintings { get; set; }
        

        private Painting selectedPainting;
        public Painting SelectedPainting
        {
            get { return selectedPainting; }
            set {
                if (value != null)
                {
                    selectedPainting = new Painting()
                    {
                        PaintingId = value.PaintingId,
                        ExhibitId = value.ExhibitId,
                        PersonId = value.PersonId,
                        Title = value.Title,
                        Painter = value.Painter,
                        Condition = value.Condition,
                        Value = value.Value,
                        YearPainted = value.YearPainted
                    };
                    OnPropertyChanged();
                    (DeletePaintingCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreatePaintingCommand { get; set; }
        public ICommand DeletePaintingCommand { get; set; }
        public ICommand UpdatePaintingCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PaintingWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Paintings = new RestCollection<Painting>("http://localhost:26918/", "painting", "hub");
                CreatePaintingCommand = new RelayCommand(() =>
                {
                    Paintings.Add(new Painting()
                    {
                        Title = SelectedPainting.Title,
                        Painter = SelectedPainting.Painter,
                        Condition = SelectedPainting.Condition,
                        Value = selectedPainting.Value,
                        YearPainted=selectedPainting.YearPainted

                    }) ;
                });

                UpdatePaintingCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Paintings.Update(SelectedPainting);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeletePaintingCommand = new RelayCommand(() =>
                {
                    Paintings.Delete(SelectedPainting.PaintingId);

                },
                () =>
                {
                    return SelectedPainting != null;
                }
               

                );
                SelectedPainting = new Painting();
            }
           
        }
    }
}
