using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.DbContexts
{
    public class ProTrackDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProTrackDbContextFactory>
    {
        public ProTrackDbContextFactory CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=protrack.db").Options;

            return new ProTrackDbContextFactory(options);
        }
    }
}
