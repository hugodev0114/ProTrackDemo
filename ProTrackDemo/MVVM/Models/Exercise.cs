using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.Models
{
    public class Exercise
    {
        private string textBoxEx5;

        public Guid Id{ get; set; }
        public string Name { get; set; }
        public Guid TrainingId { get; set; } 
        public Training Training { get; set; }
        public object ExerciseId { get; }

        public Exercise(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Exercise(object exerciseId, string name)
        {
            ExerciseId = exerciseId;
            Name = name;
        }
    }
}
