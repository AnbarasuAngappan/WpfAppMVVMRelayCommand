﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppMVVM2
{
    class ViewModel : ViewModelBase
    {
        private Student _student;

        private ObservableCollection<Student> _students;

        private ICommand _SubmitCommand;

        public ViewModel()
        {
            Student = new Student();
            Students = new ObservableCollection<Student>();
            Students.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Students_CollectionChanged);
        }

        public Student Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
                NotifyPropertyChanged("Student");
            }
        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                NotifyPropertyChanged("Students");
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit(), null);
                }
                return _SubmitCommand;
            }
        }


        private void Submit()
        {
            Student.JoiningDate = DateTime.Today.Date;
            Students.Add(Student);
            Student = new Student();
        }

       
        //Whenever new item is added to the collection, am explicitly calling notify property changed
        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Students");
        }
    }


}
