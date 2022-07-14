using Bus.Commands;
using Bus.Models;
using Bus.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bus.ViewModels
{

    public class DriverViewModel : BaseViewModel
    {
        public SchoolBusContext context { get; set; }

        public ObservableCollection<Driver> Drivers { get; set; }

        public ICommand DeleteDriverCommand { get; set; }

        public ICommand NavigateAddDriver { get; set; }

        public ICommand NavigateUpdateDriver { get; set; }

        public ICommand SearchCommand { get; set; }


        private Driver _selectedDriver;

        public Driver SelectedDriver
        {
            get { return _selectedDriver; }
            set { 
                _selectedDriver = value;
                OnPropertChanged("SelectedDriver");
            }
        }


        private string _search;

        public string Search
        {
            get { return _search; }
            set { 
                _search = value;
                SearchDrivers(_search);
                OnPropertChanged("Search");
            }
        }


        public DriverViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            Drivers = new ObservableCollection<Driver>(context.Drivers);
            DeleteDriverCommand = new RelayCommand(d => DeleteDriver());
            NavigateAddDriver = new UpdateViewCommand<AddDriverViewModel>(navigation, () => new AddDriverViewModel(navigation));
            NavigateUpdateDriver = new UpdateViewCommand<UpdateDriverViewModel>(navigation, () => new UpdateDriverViewModel(navigation, SelectedDriver));
        }


        public void DeleteDriver()
        {
            var tempDriver = SelectedDriver;

            context.Drivers.Remove(tempDriver);

            context.SaveChanges();

            Drivers.Remove(tempDriver);
        }


        public async void SearchDrivers(string Name)
        {
            if (Name.Length > 0)
            {
                var drivers = await Task.Run(() => context.Drivers.Where(d => d.FirstName.ToLower().StartsWith(Name.ToLower())));

                Drivers.Clear();

                foreach (var item in drivers)
                {
                    Drivers.Add(item);
                }
            }
            else
            {
                Drivers.Clear();
                foreach (var item in context.Drivers)
                {
                    Drivers.Add(item);
                }
            }
        }

    }
}
