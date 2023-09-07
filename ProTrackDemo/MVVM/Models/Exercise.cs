using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.Models
{
    public class Exercise
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } 

        [Required]
        public string Nom { get; set; } 

        public Guid TrainingId { get; set; } 

        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; } 

        public Exercise(string nom)
        {
            Id = Guid.NewGuid();
            Nom = nom;
        }
    }
}
