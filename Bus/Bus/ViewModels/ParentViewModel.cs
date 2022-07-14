using Bus.Commands;
using Bus.Models;
using Bus.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bus.ViewModels
{
    class ParentViewModel : BaseViewModel
    {


        public SchoolBusContext context { get; set; }

        public ObservableCollection<Parent> Parents { get; set; }

        public ICommand DeleteParentCommand { get; set; }

        public ICommand NavigateAddParent { get; set; }

        public ICommand NavigateUpdateParent { get; set; }

        public ICommand SearchCommand { get; set; }


        private Parent _selectedParent;

        public Parent SelectedParent
        {
            get { return _selectedParent; }
            set
            {
                _selectedParent = value;
                OnPropertChanged("SelectedParent");
            }
        }


        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                SearchParents(_search);
                OnPropertChanged("Search");
            }
        }


        public ParentViewModel(NavigationStore navigation)
        {
            context = new SchoolBusContext();
            Parents = new ObservableCollection<Parent>(context.Parents);
            DeleteParentCommand = new RelayCommand(d => DeleteParent());
            NavigateAddParent = new UpdateViewCommand<AddParentViewModel>(navigation, () => new AddParentViewModel(navigation));
            NavigateUpdateParent = new UpdateViewCommand<UpdateParentViewModel>(navigation, () => new UpdateParentViewModel(navigation, SelectedParent));
        }


        public void DeleteParent()
        {
            var tempParent = SelectedParent;

            context.Parents.Remove(tempParent);

            context.SaveChanges();

            Parents.Remove(tempParent);
        }


        public async void SearchParents(string Name)
        {
            if (Name.Length > 0)
            {
                var parents = await Task.Run(() => context.Parents.Where(d => d.FirstName.ToLower().StartsWith(Name.ToLower())));

                Parents.Clear();

                foreach (var item in parents)
                {
                    Parents.Add(item);
                }
            }
            else
            {
                Parents.Clear();
                foreach (var item in context.Parents)
                {
                    Parents.Add(item);
                }
            }
        }

    }
}
