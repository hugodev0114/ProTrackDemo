using ProTrackDemo.MVVM.Models;
using ProTrackDemo.Services.TrainingCreators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.Services
{
    public class TrainingService
    {
        private static ObservableCollection<Training> _trainings = new ObservableCollection<Training>();

        

        public static void CreateTraining(string trainingName, ObservableCollection<Exercise> exercises)
        {
            Training training = new Training(trainingName, exercises);

            _trainings.Add(training);

        }

        public static ObservableCollection<Training> GetTrainings() 
        {
            return _trainings;
        }


    }
}
