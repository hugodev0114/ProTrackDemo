using Microsoft.EntityFrameworkCore;
using ProTrackDemo.DbContexts;
using ProTrackDemo.DTOs;
using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.Services.TrainingCreators
{
    public class DatabaseTrainingCreator : ITrainingCreator
    {
        private readonly DbContextFactory _dbContextFactory;

        public DatabaseTrainingCreator(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateTraining(Training training)
        {
            using (ProTrackDbContextFactory context = _dbContextFactory.CreateDbContext())
            {
                TrainingDTO trainingDTO = ToTrainingDTO(training);

                context.Trainings.Add(trainingDTO);

                foreach (var exercise in training.Exercises)
                {
                    ExerciseDTO exerciseDTO = ToExerciseDTO(exercise);
                    exerciseDTO.TrainingId = trainingDTO.Id;
                    context.Exercises.Add(exerciseDTO);
                }

                try
                {
                    // Vos opérations de base de données
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // Examinez l'exception interne
                    var innerException = ex.InnerException;
                    // Loggez ou examinez cette exception pour en savoir plus sur la cause de l'erreur
                    // ...
                }
                
            }
        }

        private TrainingDTO ToTrainingDTO(Training training) 
        {
            return new TrainingDTO()
            {
                Id = training.TrainingId,
                Name = training.TrainingName,
                
            };
        }

        private ExerciseDTO ToExerciseDTO(Exercise exercise)
        {
            if (exercise == null)
            {
                return null; // Gestion d'une valeur null si nécessaire
            }

            return new ExerciseDTO
            {
                ExerciseId = exercise.Id, // S'il y a un identifiant pour l'exercice
                Name = exercise.Name,

                // Si vous avez d'autres propriétés à mapper, faites-le ici

                // TrainingId et Training sont généralement définis par la logique de votre application
                // Si vous avez déjà l'identifiant de la formation dans l'exercice, attribuez-le ici
                // Si vous avez une référence à la formation, attribuez-la ici
            };
        }

    }
}
