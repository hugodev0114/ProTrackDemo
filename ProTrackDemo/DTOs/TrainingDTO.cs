using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.DTOs
{
    public class TrainingDTO
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Exercise> Exercises { get; set; }
    }
}
