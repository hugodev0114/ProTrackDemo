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

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public ProTrackDbContextFactory(DbContextOptions options) : base(options)
        {

        }

        

    }
}
