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
using System.Windows;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class CreateRideViewModel : BaseViewModel
    {

        public ICommand NavigateBackCommand { get; set; }

        public ICommand AddStudentCommand { get; set; }

        public ICommand RemoveStudentCommand { get; set; }

        public ICommand CreateCommand { get; set; }

        public SchoolBusContext context { get; set; }

        public ObservableCollection<Driver> Drivers { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<Student> AddedStudents { get; set; }



        private Driver _driver;

        public Driver Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                OnPropertChanged("Driver");
            }
        }


        private int _studentCount;

        public int StudentCount
        {
            get { return _studentCount; }
            set
            {
                _studentCount = value;
                OnPropertChanged("StudentCount");
            }
        }


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


        private Student _selectedAddedStudent;

        public Student SelectedAddedStudent
        {
            get { return _selectedAddedStudent; }
            set
            {
                _selectedAddedStudent = value;
                OnPropertChanged("SelectedAddedStudent");
            }
        }


        public CreateRideViewModel(NavigationStore navigation)
        {

            context = new SchoolBusContext();
            Drivers = new ObservableCollection<Driver>(context.Drivers.Include(d => d.Car).Where(d => d.Car != null));
            Students = new ObservableCollection<Student>(context.Students.Include(s => s.Parent).Include(s => s.Group).ToList());
            AddedStudents = new ObservableCollection<Student>();
            StudentCount = 0;

            NavigateBackCommand = new UpdateViewCommand<DriverViewModel>(navigation, () => new DriverViewModel(navigation));
            AddStudentCommand = new RelayCommand(a => AddStudent());
            RemoveStudentCommand = new RelayCommand(r => RemoveStudent());
            CreateCommand = new RelayCommand(Create);

        }


        public void AddStudent()
        {
            if(Driver == null)
                MessageBox.Show("Choose Driver");
            else if (StudentCount < Driver.Car.SeatCount)
            {
                AddedStudents.Add(SelectedStudent);
                Students.Remove(SelectedStudent);
                StudentCount++;
            }
        }

        public void RemoveStudent()
        {
            Students.Add(SelectedAddedStudent);
            AddedStudents.Remove(SelectedAddedStudent);
            StudentCount--;
        }

        public void Create(Object obj)
        {
            var tempRide = new Ride() { Type = Driver.FirstName, Driver = Driver };
            RideStudent rideStudent;

            foreach (var student in AddedStudents)
            {
                rideStudent = new RideStudent() { Ride = tempRide, Student = student };
                context.RideStudents.Add(rideStudent);
            }

            context.SaveChanges();
            NavigateBackCommand.Execute(obj);
        }

    }
}
