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
    class PersonWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Person> People { get; set; }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (value != null)
                {
                    selectedPerson = new Person()
                    {
                        PersonId = value.PersonId,     
                        Name = value.Name,
                        PhoneNumber = value.PhoneNumber,
                        Email = value.Email,
                        BirthYear = value.BirthYear,
                        ZipCode = value.ZipCode
                    };
                    OnPropertyChanged();
                    (DeletePersonCommand as RelayCommand).NotifyCanExecuteChanged();

    }
            }

        }
        public ICommand CreatePersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand UpdatePersonCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public PersonWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                People = new RestCollection<Person>("http://localhost:26918/", "person", "hub");
                CreatePersonCommand = new RelayCommand(() =>
                {
                    People.Add(new Person()
                    {
                       
                        Name = selectedPerson.Name,
                        PhoneNumber = selectedPerson.PhoneNumber,
                        Email = selectedPerson.Email,
                        BirthYear = selectedPerson.BirthYear,
                        ZipCode = selectedPerson.ZipCode

                    });
                });

                UpdatePersonCommand = new RelayCommand(() =>
                {
                    try
                    {
                        People.Update(SelectedPerson);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeletePersonCommand = new RelayCommand(() =>
                {
                    People.Delete(SelectedPerson.PersonId);

                },
                () =>
                {
                    return SelectedPerson != null;
                }


                );
                SelectedPerson = new Person();
            }

        }
    }
}
