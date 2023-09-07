using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.DTOs
{
    public class ExerciseDTO
    {
     
        public Guid ExerciseId { get; set; }
        public string? Name { get; set; }
        public Guid TrainingId { get; set; } // Clé étrangère vers Training
        public Training Training { get; set; }

    }
}
