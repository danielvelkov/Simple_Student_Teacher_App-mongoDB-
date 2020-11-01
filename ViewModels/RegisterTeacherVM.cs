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
using System.Windows.Input;

namespace StudentTest.ViewModels
{
    class RegisterTeacherVM : BaseViewModel, IPageViewModel
    {
        private ObservableCollection<User> users { get; set; }
        private ICommand _saveTeacher;
        ICommand _addSubject;
        ICommand _removeSubject;


        private string name;
        private string civilNum;
        private Faculty teacherFaculty;
        private string phoneNum;
        private string email;

        string errMsg;

        List<Subject> subjects;
        Subject selectedSubject;
        ObservableCollection<Subject> taughtSubjects;
        Subject selectedTaughtSubject;

        public Array Faculties
        {
            get { return Enum.GetValues(typeof(Faculty)); }
        }

        public RegisterTeacherVM() { }

        public RegisterTeacherVM(ObservableCollection<User> users)
        {
            this.users = users;
        }

        public string NameOfPage
        {
            get
            {
                return "Register teacher";
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string CivilNum
        {
            get { return civilNum; }
            set
            {
                if (civilNum != value)
                {
                    civilNum = value;
                    OnPropertyChanged("CivilNum");
                }
            }
        }

        public Faculty TeacherFaculty
        {
            get { return teacherFaculty; }
            set
            {
                if (teacherFaculty != value)
                {
                    teacherFaculty = value;
                    OnPropertyChanged("TeacherFaculty");
                }
            }
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set
            {
                if (phoneNum != value)
                {
                    phoneNum = value;
                    OnPropertyChanged("PhoneNum");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string ErrMsg
        {
            get { return errMsg; }
            set
            {
                if (errMsg != value)
                {
                    errMsg = value;
                    OnPropertyChanged("ErrMsg");
                }
            }
        }

        public List<Subject> Subjects
        {
            get
            {
                if (subjects == null || !subjects.Any())
                {
                    subjects = Factory.GetSubjects().AsQueryable().ToList<Subject>();
                    return subjects;
                }
                return subjects;
            }
        }

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (selectedSubject != value)
                {
                    selectedSubject = value;
                    OnPropertyChanged("SelectedSubject");
                }
            }
        }

        public ObservableCollection<Subject> TaughtSubjects
        {
            get
            {
                if (taughtSubjects == null)
                {
                    taughtSubjects = new ObservableCollection<Subject>();
                }
                return taughtSubjects;
            }
        }

        public Subject SelectedTaughtSubject
        {
            get { return selectedTaughtSubject; }
            set
            {
                if (selectedTaughtSubject != value)
                {
                    selectedTaughtSubject = value;
                    OnPropertyChanged("SelectedTaughtSubject");
                }
            }
        }

        void AddSelectedSubject()
        {
            foreach (Subject subject in TaughtSubjects)
            {
                if (selectedSubject.Name == subject.Name)
                    return;
            }
            TaughtSubjects.Add(selectedSubject);
            OnPropertyChanged("TaughtSubjects");
        }

        void RemoveSelectedSubject()
        {
            if (selectedTaughtSubject != null)
            {
                TaughtSubjects.Remove((
                from subject in TaughtSubjects
                where selectedTaughtSubject.Name == subject.Name
                select subject).FirstOrDefault());
                OnPropertyChanged("StudySubjects");
            }
            
        }
        
        void AddTeacher()
        {
            Teacher teacher = new Teacher(
                Name,
                CivilNum,
                PhoneNum,
                Email,
                TeacherFaculty,
                TaughtSubjects.ToList());
            TeacherValidation.ActionOnError act = Error;
            TeacherValidation tv = new TeacherValidation(act);
            if (tv.isTeacherValid(teacher))
            {
                users.Add(teacher);
                ErrMsg = "Teacher " + teacher.Name + " added!";
                Factory.GetTeachers().InsertOne(teacher);
            }

        }

        public ICommand SaveTeacher
        {
            get
            {
                if (_saveTeacher == null)
                {
                    _saveTeacher = new RelayCommand(AddTeacher);
                }
                return _saveTeacher;
            }
        }

        public ICommand AddSubject
        {
            get
            {
                if (_addSubject == null)
                {
                    _addSubject = new RelayCommand(AddSelectedSubject);
                }
                return _addSubject;
            }
        }

        public ICommand RemoveSubject
        {
            get
            {
                if (_removeSubject == null)
                {
                    _removeSubject = new RelayCommand(RemoveSelectedSubject);
                }
                return _removeSubject;
            }
        }

        void Error(string err)
        {
            ErrMsg = "* " + err;
        }
    }
}