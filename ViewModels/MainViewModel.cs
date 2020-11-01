using MongoDB.Driver;
using StudentTest.Helper;
using StudentTest.Model;
using StudentTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTest.Views
{
    class MainViewModel:BaseViewModel
    {
        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get {
                if (users == null || !users.Any())
                {
                    List<Student> students = Factory.GetStudents().AsQueryable().ToList();
                    List<Teacher> teachers = Factory.GetTeachers().AsQueryable().ToList();
                    users = new ObservableCollection<User>();
                    foreach (Student stud in students)
                        users.Add(stud);
                    foreach (Teacher teach in teachers)
                        users.Add(teach);
                }
                return users;
            }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnPropertyChanged("Users");
                }
            }
        }

        public MainViewModel()
        {
            // Add available pages

            PageViewModels.Add(new RegisterStudentVM(Users));
            PageViewModels.Add(new RegisterTeacherVM(Users));
            PageViewModels.Add(new StudentListVM(Users));

            // Set starting page
            CurrentPageViewModel = PageViewModels[2];
        }
        
        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(ChangeViewModel);
                }

                return _changePageCommand;
            }
        }
        
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
        
    }
}
