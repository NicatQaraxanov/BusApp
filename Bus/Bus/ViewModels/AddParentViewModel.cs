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
    class AddParentViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand AddParentCommand { get; set; }

        public SchoolBusContext context { get; set; }


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




        public AddParentViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            AddParentCommand = new RelayCommand(AddParent);
            NavigateBackCommand = new UpdateViewCommand<ParentViewModel>(navigation, () => new ParentViewModel(navigation));
        }


        public void AddParent(Object obj)
        {
            var temp = new Parent() { FirstName = FirstName, LastName = LastName, UserName = Username, Phone = Phone, Password = Password };
            context.Add(temp);
            context.SaveChanges();
            NavigateBackCommand.Execute(obj);
        }

    }
}
