using Microsoft.Win32;
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
using System.Windows.Input;

namespace StudentTest.ViewModels
{
    class RegisterStudentVM : BaseViewModel, IPageViewModel
    {
        public string NameOfPage
        {
            get
            {
                return "Register student";
            }
        }
        
        string name;
        string facNumber;
        Faculty faculty;
        string courseName;
        TypeOfStudy typeStudy;
        Degree degreeType;
        int group;
        string civilNum;
        Uri image;

        string errMsg;

        List<Subject> subjects;
        Subject selectedSubject;
        ObservableCollection<Subject> studySubjects;
        Subject selectedStudySubject;

        public Array faculties
        {
            get { return Enum.GetValues(typeof(Faculty)); }
        }

        public Array studyTypes
        {
            get { return Enum.GetValues(typeof(TypeOfStudy)); }

        }

        public Array degreeTypes
        {
            get { return Enum.GetValues(typeof(Degree)); }

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

        public string FacNum
        {
            get { return facNumber; }
            set
            {
                if (facNumber != value)
                {
                    facNumber = value;
                    OnPropertyChanged("FacNum");
                }
            }
        }

        public string CivilNumber
        {
            get { return civilNum; }
            set
            {
                if (civilNum != value)
                {
                    civilNum = value;
                    OnPropertyChanged("CivilNumber");
                }
            }
        }

        public Faculty StudFaculty
        {
            get { return faculty; }
            set
            {
                if (faculty != value)
                {
                    faculty = value;
                    OnPropertyChanged("StudFaculty");
                }
            }
        }

        public string CourseName
        {
            get { return courseName; }
            set
            {
                if (courseName != value)
                {
                    courseName = value;
                    OnPropertyChanged("CourseName");
                }
            }
        }

        public TypeOfStudy TypeStudy
        {
            get { return typeStudy; }
            set
            {
                if (typeStudy != value)
                {
                    typeStudy = value;
                    OnPropertyChanged("TypeStudy");
                }
            }
        }

        public Degree TypeDegree
        {
            get { return degreeType; }
            set
            {
                if (degreeType != value)
                {
                    degreeType = value;
                    OnPropertyChanged("TypeDegree");
                }
            }
        }

        public int Group
        {
            get { return group; }
            set
            {
                if (group != value)
                {
                    group = value;
                    OnPropertyChanged("Group");
                }
            }
        }

        public Uri ImageUri
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged("ImageUri");
                }
            }
        }

        public List<Subject> Subjects
        {
            get { if (subjects==null || !subjects.Any())
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
            set { if (selectedSubject != value)
                {
                    selectedSubject = value;
                    OnPropertyChanged("SelectedSubject");
                } }
        }

        
        public ObservableCollection<Subject> StudySubjects
        {
            get
            {
                if (studySubjects == null)
                {
                    studySubjects= new ObservableCollection<Subject>();
                }
                return studySubjects;
            }
        }

        public Subject SelectedStudySubject
        {
            get { return selectedStudySubject; }
            set { if (selectedStudySubject != value)
                {
                    selectedStudySubject = value;
                    OnPropertyChanged("SelectedStudySubject");
                } }
        }

        ICommand _saveStudent;
        ICommand _addImage;
        ICommand _addSubject;
        ICommand _removeSubject;

        public ICommand SaveStudent
        {
            get
            {
                if (_saveStudent == null)
                {
                    _saveStudent = new RelayCommand(AddStud);
                }
                return _saveStudent;
            }
        }

        public ICommand AddImage
        {
            get
            {
                if (_addImage == null)
                {
                    _addImage = new RelayCommand(TakeImage);
                }
                return _addImage;
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

        ObservableCollection<User> studList { get; set; }

        public RegisterStudentVM() { }

        public RegisterStudentVM(ObservableCollection<User> users)
        {
            studList = users;

        }

        void AddStud()
        {
            Student stud = new Student(
                Name,
                CivilNumber,
                FacNum,
                StudFaculty,
                CourseName,
                TypeStudy,
                TypeDegree,
                Group,
                StudySubjects.ToList(),
                ImageUri
                );
            StudentValidation.ActionOnError act = Error;
            StudentValidation sv = new StudentValidation(act);
            if (sv.isStudentValid(stud))
            {
                studList.Add(stud);
                ErrMsg = "Student "+ stud.Name+" added!";
                Factory.GetStudents().InsertOne(stud);
            }
        }

        void TakeImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg)|*.jpg|Image files (*.png)|*.png|All files (*.*)|*.*";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fileDialog.ShowDialog() == true)
            {
                
                ImageUri =new Uri( fileDialog.FileName,UriKind.Absolute);
            }
        }

        void AddSelectedSubject()
        {
            
            foreach (Subject subject in StudySubjects)
            {
                if (selectedSubject.Name == subject.Name)
                    return;
            }
            StudySubjects.Add(selectedSubject);
            OnPropertyChanged("StudySubjects");
        }

        void RemoveSelectedSubject()
        {
            if (selectedStudySubject != null)
            {
                StudySubjects.Remove((
               from subject in StudySubjects
               where selectedStudySubject.Name == subject.Name
               select subject).FirstOrDefault());
                OnPropertyChanged("StudySubjects");
            }
               
        }

        void Error(string err)
        {
            ErrMsg = "*" + err;
        }
    }
}
