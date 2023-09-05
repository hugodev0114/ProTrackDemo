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
        public Training() 
        {

        }
        public ObservableCollection<Exercise> Exercises { get; set; } = new ObservableCollection<Exercise>();
        
        public string TrainingName { get; set; }
        public Guid TrainingId { get; set; }
        public Guid Id { get; }
        public string Name { get; }

        public Training(Guid trainingId, string trainingName, ObservableCollection<Exercise> exercises)
        {
            TrainingName = trainingName;
            TrainingId = trainingId;
            Exercises = exercises;
            TrainingId = Guid.NewGuid();
        }

        public Training(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
