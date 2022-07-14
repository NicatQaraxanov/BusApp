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
    class UpdateDriverViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand UpdateDriverCommand { get; set; }

        public SchoolBusContext context { get; set; }

        public Driver Driver { get; set; }


        public UpdateDriverViewModel(NavigationStore navigation, Driver dv)
        {
            context = new SchoolBusContext();
            NavigateBackCommand = new UpdateViewCommand<DriverViewModel>(navigation, () => new DriverViewModel(navigation));
            UpdateDriverCommand = new RelayCommand(UpdateDriver);
            Driver = dv;
        }

        
        public void UpdateDriver(Object obj)
        {
            context.Update(Driver);

            context.SaveChanges();

            NavigateBackCommand.Execute(obj);
        }

    }
}
