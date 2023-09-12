using ProTrackDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.Services.TrainingCreators
{
    public interface ITrainingCreator
    {
        Task CreateTraining(Training training);

        Task DeleteTraining(Guid trainingId);
    }
}
