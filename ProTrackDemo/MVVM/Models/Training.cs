using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.Models
{
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; } // Propriété pour le nom du training.
        public virtual List<Exercise> Exercises { get; } = new List<Exercise>(); // Liste d'exercices associée à ce training.

        public Training()
        {
            
        }

        public Training(string nom, List<Exercise> exercises)
        {
            Id = Guid.NewGuid(); // Générer un GUID unique lors de la création de l'objet.
            Nom = nom;
            Exercises = exercises;
        }
    }
}
