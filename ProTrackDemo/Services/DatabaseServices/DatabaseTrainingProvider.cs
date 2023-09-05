using Microsoft.EntityFrameworkCore;
using ProTrackDemo.DbContexts;
using ProTrackDemo.DTOs;
using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.Services.DatabaseServices
{
    public class DatabaseTrainingProvider : ITrainingServiceProvider
    {
        private readonly DbContextFactory _dbContextFactory;

        public DatabaseTrainingProvider(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {

            using (ProTrackDbContextFactory context = _dbContextFactory.CreateDbContext())
            {
                var trainingDTOs = await context.Trainings
                    .Include(t => t.Exercises) // Inclure les exercices associés au training
                    .ToListAsync();

                return trainingDTOs.Select(dto => ToTraining(dto));
            }
        }

        private static Training ToTraining(TrainingDTO trainingDTO)
        {

            var training = new Training(trainingDTO.Id, trainingDTO.Name);

            foreach (var exerciseDTO in trainingDTO.Exercises)
            {
                var exercise = new Exercise(exerciseDTO.ExerciseId, exerciseDTO.Name);
                training.Exercises.Add(exercise);
            }

            return training;
        }
    }
}
