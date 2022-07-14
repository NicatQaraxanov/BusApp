using Bus.Commands;
using Bus.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigation;

        public BaseViewModel SelectedViewModel { get; set; }

        public ICommand NavigateDriverCommand { get; set; }

        public ICommand NavigateCarCommand { get; set; }

        public ICommand NavigateParentCommand { get; set; }

        public ICommand NavigateClassCommand { get; set; }

        public ICommand NavigateStudentCommand { get; set; }

        public ICommand NavigateCreateRideCommand { get; set; }

        public ICommand NavigateRideCommand { get; set; }


        public MainViewModel(NavigationStore navigation)
        {
            _navigation = navigation;
            _navigation.SelectedViewModelChanged += OnSelectedViewChanged;
            SelectedViewModel = _navigation.SelectedViewModel;

            NavigateDriverCommand = new UpdateViewCommand<DriverViewModel>(navigation, () => new DriverViewModel(navigation));
            NavigateCarCommand = new UpdateViewCommand<CarViewModel>(navigation, () => new CarViewModel(navigation));
            NavigateParentCommand = new UpdateViewCommand<ParentViewModel>(navigation, () => new ParentViewModel(navigation));
            NavigateClassCommand = new UpdateViewCommand<ClassViewModel>(navigation, () => new ClassViewModel(navigation));
            NavigateStudentCommand = new UpdateViewCommand<StudentViewModel>(navigation, () => new StudentViewModel(navigation));
            NavigateCreateRideCommand = new UpdateViewCommand<CreateRideViewModel>(navigation, () => new CreateRideViewModel(navigation));
            NavigateRideCommand = new UpdateViewCommand<RideViewModel>(navigation, () => new RideViewModel(navigation));
        }

        protected void OnSelectedViewChanged()
        {
            SelectedViewModel = _navigation.SelectedViewModel;
            OnPropertChanged(nameof(SelectedViewModel));
        }

    }
}
