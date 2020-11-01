using MongoDB.Driver;
using StudentTest.Helper;
using StudentTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTest.ViewModels
{
    class StudentListVM : BaseViewModel,IPageViewModel
    {
        ObservableCollection<User> users;
        User selectedUser;
        

        public ObservableCollection<User> Users
        {
            get
            {
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

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                    OnPropertyChanged("typeOfSelectedUser");
                }
            }
        }

        public string typeOfSelectedUser
        {
            get
            {
                if (selectedUser == null)
                {
                    return String.Empty;
                }
                else return selectedUser.ToString();
            }
        }

        public string NameOfPage
        {
            get
            {
                return "Show all";
            }
        }
        
        public StudentListVM() { }
        public StudentListVM(ObservableCollection<User> users)
        {
            this.users = users;
        }

    }
}
