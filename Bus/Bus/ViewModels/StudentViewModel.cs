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
    class StudentViewModel : BaseViewModel
    {

        public SchoolBusContext context { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public ICommand DeleteStudentCommand { get; set; }

        public ICommand NavigateAddStudent { get; set; }

        public ICommand NavigateUpdateStudent { get; set; }

        public ICommand SearchCommand { get; set; }


        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertChanged("SelectedStudent");
            }
        }


        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                SearchStudents(_search);
                OnPropertChanged("Search");
            }
        }


        public StudentViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            Students = new ObservableCollection<Student>(context.Students.Include(s => s.Parent).Include(s => s.Group).ToList());


            DeleteStudentCommand = new RelayCommand(d => DeleteStudent());
            NavigateAddStudent = new UpdateViewCommand<AddStudentViewModel>(navigation, () => new AddStudentViewModel(navigation));
            NavigateUpdateStudent = new UpdateViewCommand<UpdateStudentViewModel>(navigation, () => new UpdateStudentViewModel(navigation, SelectedStudent));
        }


        public void DeleteStudent()
        {
            var temp = SelectedStudent;

            context.Students.Remove(temp);

            context.SaveChanges();

            Students.Remove(temp);
        }


        public async void SearchStudents(string Name)
        {
            if (Name.Length > 0)
            {
                var students = await Task.Run(() => context.Students.Where(s => s.FirstName.ToLower().StartsWith(Name.ToLower())));

                Students.Clear();

                foreach (var item in students)
                {
                    Students.Add(item);
                }
            }
            else
            {
                Students.Clear();
                foreach (var item in context.Students)
                {
                    Students.Add(item);
                }
            }
        }

    }
}
