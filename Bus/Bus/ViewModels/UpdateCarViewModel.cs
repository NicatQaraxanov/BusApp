using Bus.Commands;
using Bus.Models;
using Bus.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class UpdateCarViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand UpdateCarCommand { get; set; }

        public SchoolBusContext context { get; set; }

        private Car _car;

        public Car Car
        {
            get { return _car; }
            set { 
                _car = value;
                OnPropertChanged("Car");
            }
        }


        private string _driverName;

        public string DriverName
        {
            get { return _driverName; }
            set
            {
                _driverName = value;
                OnPropertChanged("DriverName");
            }
        }


        private List<string> _driverNames;

        public List<string> DriverNames
        {
            get { return _driverNames; }
            set
            {
                _driverNames = value;
                OnPropertChanged("DriverNames");
            }
        }


        public UpdateCarViewModel(NavigationStore navigation, Car cr)
        {
            context = new SchoolBusContext();
            NavigateBackCommand = new UpdateViewCommand<CarViewModel>(navigation, () => new CarViewModel(navigation));
            UpdateCarCommand = new RelayCommand(UpdateCar);
            Car = cr;

            if (context.Drivers.Count() > 0)
                DriverNames = context.Drivers.Where(d => d.Car == null).Select(d => d.FirstName).ToList();

            if (Car.DriverId != null)
            {
                DriverName = Car.Driver.FirstName;
                DriverNames.Add(Car.Driver.FirstName);
            }
        }


        public void UpdateCar(Object obj)
        {
            Car.Driver = context.Drivers.FirstOrDefault(d => d.FirstName == DriverName);

            context.Update(Car);

            context.SaveChanges();

            NavigateBackCommand.Execute(obj);
        }

    }
}
