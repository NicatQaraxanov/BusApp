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
    class RideViewModel : BaseViewModel
    {

        public SchoolBusContext context { get; set; }

        public ObservableCollection<Ride> Rides { get; set; }

        public ICommand DeleteRideCommand { get; set; }



        private Ride _selectedRide;

        public Ride SelectedRide
        {
            get { return _selectedRide; }
            set
            {
                _selectedRide = value;
                OnPropertChanged("SelectedRide");
            }
        }


        public RideViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            Rides = new ObservableCollection<Ride>(context.Rides.Include(r => r.Driver).Include(r => r.RideStudents).ThenInclude(rs => rs.Student).ToList());
            DeleteRideCommand = new RelayCommand(d => DeleteRide());
        }


        public void DeleteRide()
        {
            var tempRide = SelectedRide;

            context.Rides.Remove(SelectedRide);

            context.SaveChanges();

            Rides.Remove(tempRide);
        }

    }
}
