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
    class UpdateClassViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand UpdateClassCommand { get; set; }

        public SchoolBusContext context { get; set; }

        public Group TempClass { get; set; }



        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertChanged("Title");
            }
        }

        public UpdateClassViewModel(NavigationStore navigation, Group dv)
        {
            context = new SchoolBusContext();
            NavigateBackCommand = new UpdateViewCommand<ClassViewModel>(navigation, () => new ClassViewModel(navigation));
            UpdateClassCommand = new RelayCommand(UpdateClass);
            TempClass = dv;

            Title = TempClass.Title;
        }


        public void UpdateClass(Object obj)
        {
            TempClass.Title = Title;

            context.Update(TempClass);

            context.SaveChanges();

            NavigateBackCommand.Execute(obj);
        }

    }
}
