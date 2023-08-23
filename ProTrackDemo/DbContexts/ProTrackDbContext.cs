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
    public class ProTrackDbContext : DbContext
    {
        public ProTrackDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TrainingDTO> Trainings { get; set; }
    }
}
