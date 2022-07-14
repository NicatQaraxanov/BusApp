using Bus.Commands;
using Bus.Models;
using Bus.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class AddCarViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand AddCarCommand { get; set; }

        public SchoolBusContext context { get; set; }


        private Car _car;

        public Car Car
        {
            get { return _car; }
            set
            {
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


        public AddCarViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            AddCarCommand = new RelayCommand(AddCar);
            NavigateBackCommand = new UpdateViewCommand<CarViewModel>(navigation, () => new CarViewModel(navigation));

            Car = new Car();

            if (context.Drivers.Count() > 0)
                DriverNames = context.Drivers.Where(d => d.Car == null).Select(d => d.FirstName).ToList();
        }


        public void AddCar(Object obj)
        {
            Car.Driver = context.Drivers.FirstOrDefault(d => d.FirstName == DriverName);
            context.Add(Car);
            context.SaveChanges();
            NavigateBackCommand.Execute(obj);
        }

    }
}
