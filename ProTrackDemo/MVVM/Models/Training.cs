using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.Models
{
    public class Training
    {
        public Training(string trainingName, ObservableCollection<Exercise> exercises)
        {
            TrainingName = trainingName;
            Exercises = exercises;
        }

        public ObservableCollection<Exercise> Exercises { get; set; } = new ObservableCollection<Exercise>();
        
        public string TrainingName { get; }
        
    }
}
