using ProTrackDemo.Core;
using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.ViewModels
{
    public class TrainingViewModel : ViewModel
    {

        private Training _selectedTraining;
        public Training SelectedTraining
        {
            get => _selectedTraining;
            set
            {
                _selectedTraining = value;
                OnPropertyChanged(nameof(SelectedTraining));
            }   
        }


    }
}
