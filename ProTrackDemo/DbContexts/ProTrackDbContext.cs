using Microsoft.EntityFrameworkCore;
using ProTrackDemo.DTOs;
using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.DbContexts
{
    public class ProTrackDbContextFactory : DbContext
    {

        public DbSet<TrainingDTO> Trainings { get; set; }
        public DbSet<ExerciseDTO> Exercises { get; set; }

        public ProTrackDbContextFactory(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Training>()
                .HasMany(t => t.Exercises)
                .WithOne(e => e.Training)
                .HasForeignKey(e => e.TrainingId);
        }

    }
}
