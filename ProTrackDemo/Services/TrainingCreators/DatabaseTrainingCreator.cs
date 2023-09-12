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

                
                
                //training.Exercises.AddRange(training.Exercises);
                foreach(Exercise exercise in training.Exercises) 
                {
                    exercise.Training = training;
                    exercise.TrainingId = training.Id;
                }


                context.Trainings.Add(training);
                context.SaveChanges();

            }
        }

        public async Task DeleteTraining(Guid trainingId)
        {
            using (ProTrackDbContextFactory context = _dbContextFactory.CreateDbContext())
            {
                // Recherchez le training à supprimer par son ID
                var trainingToRemove = await context.Trainings.FindAsync(trainingId);

                if (trainingToRemove != null)
                {
                    // Supprimez le training de la base de données
                    context.Trainings.Remove(trainingToRemove);
                    await context.SaveChangesAsync();
                }
            }
        }

    }
}
