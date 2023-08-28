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
                IEnumerable<TrainingDTO> trainingDTOs = await context.Trainings.ToListAsync();

                return  trainingDTOs.Select(x => ToTraining(x));
            }
        }

        private static Training ToTraining(TrainingDTO trainingDTO)
        {
            return new Training(trainingDTO.Id, trainingDTO.Name);
        }
    }
}
