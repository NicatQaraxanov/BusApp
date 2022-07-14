using Bus.Commands;
using Bus.Models;
using Bus.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class AddStudentViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand AddStudentCommand { get; set; }

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


        private string _homeAddress;

        public string HomeAddress
        {
            get { return _homeAddress; }
            set
            {
                _homeAddress = value;
                OnPropertChanged("HomeAddress");
            }
        }


        private string _otherAddress;

        public string OtherAddress
        {
            get { return _otherAddress; }
            set
            {
                _otherAddress = value;
                OnPropertChanged("OtherAddress");
            }
        }


        private List<string> _parentNames;

        public List<string> ParentNames
        {
            get { return _parentNames; }
            set
            {
                _parentNames = value;
                OnPropertChanged("ParentNames");
            }
        }

        private string _parentName;

        public string ParentName
        {
            get { return _parentName; }
            set
            {
                _parentName = value;
                OnPropertChanged("ParentName");
            }
        }


        private List<string> _classNames;

        public List<string> ClassNames
        {
            get { return _classNames; }
            set
            {
                _classNames = value;
                OnPropertChanged("ClassNames");
            }
        }

        private string _className;

        public string ClassName
        {
            get { return _className; }
            set { 
                _className = value;
                OnPropertChanged("ClassName");
            }
        }



        public AddStudentViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            AddStudentCommand = new RelayCommand(AddStudent);
            NavigateBackCommand = new UpdateViewCommand<StudentViewModel>(navigation, () => new StudentViewModel(navigation));

            ParentNames = context.Parents.Select(p => p.FirstName).ToList();
            ClassNames = context.Groups.Select(g => g.Title).ToList();
        }


        public void AddStudent(Object obj)
        {
            try
            {
                var temp = new Student() { FirstName = FirstName, LastName = LastName, Home = HomeAddress, OtherAddress = OtherAddress, Parent = context.Parents.FirstOrDefault(p => p.FirstName == ParentName), Group = context.Groups.FirstOrDefault(g => g.Title == ClassName) };
                context.Add(temp);
                context.SaveChanges();
                NavigateBackCommand.Execute(obj);
            }
            catch (Exception)
            {
                MessageBox.Show("You need to enter Parent/Class");
            }
        }

    }
}
