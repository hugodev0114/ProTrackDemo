using ProTrackDemo.Core;
using ProTrackDemo.MVVM.Models;
using ProTrackDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace ProTrackDemo.MVVM.ViewModels
{
    public class RegisterTrainingViewModel : ViewModel
    {

        private string _textBoxTrainingName;
        public string TextBoxTrainingName
        {
            get 
            { 
                return _textBoxTrainingName; 
            } 
            set 
            { 
                _textBoxTrainingName = value;
                OnPropertyChanged(nameof(TextBoxTrainingName));
            }
        }

        private string _textBoxEx1;
        public string TextBoxEx1
        {
            get
            {
                return _textBoxEx1;
            }
            set
            {
                _textBoxEx1 = value;
                OnPropertyChanged(nameof(TextBoxEx1));
            }
        }

        private string _textBoxEx2;
        public string TextBoxEx2
        {
            get
            {
                return _textBoxEx2;
            }
            set
            {
                _textBoxEx2 = value;
                OnPropertyChanged(nameof(TextBoxEx2));
            }
        }

        private string _textBoxEx3;
        public string TextBoxEx3
        {
            get
            {
                return _textBoxEx3;
            }
            set
            {
                _textBoxEx3 = value;
                OnPropertyChanged(nameof(TextBoxEx3));
            }
        }

        private string _textBoxEx4;
        public string TextBoxEx4
        {
            get
            {
                return _textBoxEx4;
            }
            set
            {
                _textBoxEx4 = value;
                OnPropertyChanged(nameof(TextBoxEx4));
            }
        }

        private string _textBoxEx5;
        public string TextBoxEx5
        {
            get
            {
                return _textBoxEx5;
            }
            set
            {
                _textBoxEx5 = value;
                OnPropertyChanged(nameof(TextBoxEx5));
            }
        }
        public ICommand SubmitCommand { get; private set; }

        public RegisterTrainingViewModel()
        {
            SubmitCommand = new RelayCommand(_ => { return true; }, parameter => { Submit(); });
        }

        private void Submit()
        {
            ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();
            exercises.Add(new Exercise(TextBoxEx1));
            exercises.Add(new Exercise(TextBoxEx2));
            exercises.Add(new Exercise(TextBoxEx3));
            exercises.Add(new Exercise(TextBoxEx4));
            exercises.Add(new Exercise(TextBoxEx5));
            TrainingService.CreateTraining(TextBoxTrainingName, exercises);
        }
    }
}
