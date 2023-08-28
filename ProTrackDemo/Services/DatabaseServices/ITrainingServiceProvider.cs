using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.Services.DatabaseServices
{
    public interface ITrainingServiceProvider
    {
        Task<IEnumerable<Training>> GetAllTrainings();
    }
}
