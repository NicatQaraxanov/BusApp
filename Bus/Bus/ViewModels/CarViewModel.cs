using Bus.Commands;
using Bus.Models;
using Bus.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class CarViewModel : BaseViewModel
    {

        public SchoolBusContext context { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        public ICommand DeleteCarCommand { get; set; }

        public ICommand NavigateAddCar { get; set; }

        public ICommand NavigateUpdateCar { get; set; }

        public ICommand SearchCommand { get; set; }


        private Car _selectedCar;

        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertChanged("SelectedDriver");
            }
        }


        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                SearchCars(_search);
                OnPropertChanged("Search");
            }
        }


        public CarViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            Cars = new ObservableCollection<Car>(context.Cars.Include(c => c.Driver).ToList());

            DeleteCarCommand = new RelayCommand(d => DeleteCar());
            NavigateAddCar = new UpdateViewCommand<AddCarViewModel>(navigation, () => new AddCarViewModel(navigation));
            NavigateUpdateCar = new UpdateViewCommand<UpdateCarViewModel>(navigation, () => new UpdateCarViewModel(navigation, SelectedCar));
        }


        public void DeleteCar()
        {
            var temp = SelectedCar;

            context.Cars.Remove(temp);

            context.SaveChanges();

            Cars.Remove(temp);
        }


        public async void SearchCars(string Name)
        {
            if (Name.Length > 0)
            {
                var cars = await Task.Run(() => context.Cars.Where(d => d.Title.ToLower().StartsWith(Name.ToLower())));

                Cars.Clear();

                foreach (var item in cars)
                {
                    Cars.Add(item);
                }
            }
            else
            {
                Cars.Clear();
                foreach (var item in context.Cars)
                {
                    Cars.Add(item);
                }
            }
        }

    }
}
