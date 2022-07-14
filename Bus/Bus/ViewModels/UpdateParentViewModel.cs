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
    class UpdateParentViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand UpdateParentCommand { get; set; }

        public SchoolBusContext context { get; set; }

        public Parent TempParent { get; set; }



        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertChanged("FirstName");
            }
        }


        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertChanged("LastName");
            }
        }


        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertChanged("Username");
            }
        }


        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertChanged("Phone");
            }
        }


        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertChanged("Password");
            }
        }


        public UpdateParentViewModel(NavigationStore navigation, Parent dv)
        {
            context = new SchoolBusContext();
            NavigateBackCommand = new UpdateViewCommand<ParentViewModel>(navigation, () => new ParentViewModel(navigation));
            UpdateParentCommand = new RelayCommand(UpdateDriver);
            TempParent = dv;

            FirstName = TempParent.FirstName;
            LastName = TempParent.LastName;
            Phone = TempParent.Phone;
            Password = TempParent.Password;
            Username = TempParent.UserName;
        }


        public void UpdateDriver(Object obj)
        {
            TempParent.FirstName = FirstName;
            TempParent.LastName = LastName;
            TempParent.Phone = Phone;
            TempParent.Password = Password;

            context.Update(TempParent);

            context.SaveChanges();

            NavigateBackCommand.Execute(obj);
        }

    }
}
