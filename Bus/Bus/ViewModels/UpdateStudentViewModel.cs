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
    class UpdateStudentViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand UpdateStudentCommand { get; set; }

        public SchoolBusContext context { get; set; }

        public Student TempStudent { get; set; }



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
            set
            {
                _className = value;
                OnPropertChanged("ClassName");
            }
        }


        public UpdateStudentViewModel(NavigationStore navigation, Student st)
        {
            context = new SchoolBusContext();
            NavigateBackCommand = new UpdateViewCommand<StudentViewModel>(navigation, () => new StudentViewModel(navigation));
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
            ParentNames = new List<string>();
            ClassNames = new List<string>();
            TempStudent = st;


            FirstName = TempStudent.FirstName;
            LastName = TempStudent.LastName;
            HomeAddress = TempStudent.Home;
            OtherAddress = TempStudent.OtherAddress;


            if (context.Parents.Count() > 0)
                ParentNames = context.Parents.Select(p => p.FirstName).ToList();

            if(context.Groups.Count() > 0)
                ClassNames = context.Groups.Select(g => g.Title).ToList();



            if (TempStudent.Parent != null)
            {
                ParentName = TempStudent.Parent.FirstName;
            }

            if (TempStudent.Group != null)
            {
                ClassName = TempStudent.Group.Title;
            }

        }


        public void UpdateStudent(Object obj)
        {
            TempStudent.FirstName = FirstName;
            TempStudent.LastName = LastName;
            TempStudent.Home = HomeAddress;
            TempStudent.OtherAddress = OtherAddress;
            TempStudent.Parent = context.Parents.FirstOrDefault(p => p.FirstName == ParentName);
            TempStudent.Group = context.Groups.FirstOrDefault(g => g.Title == ClassName);

            context.Update(TempStudent);

            context.SaveChanges();

            NavigateBackCommand.Execute(obj);
        }

    }
}
