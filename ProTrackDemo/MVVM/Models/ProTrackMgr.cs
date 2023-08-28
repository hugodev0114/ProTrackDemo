using ProTrackDemo.Services.DatabaseServices;
using ProTrackDemo.Services.TrainingCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.Models
{
    public class ProTrackMgr
    {
        private readonly ITrainingCreator _databaseTrainingCreator;
        private readonly ITrainingServiceProvider _databaseTrainingProvider;

        public ProTrackMgr(ITrainingCreator databaseTrainingCreator, ITrainingServiceProvider databaseTrainingProvider)
        {
            _databaseTrainingCreator = databaseTrainingCreator;
            _databaseTrainingProvider = databaseTrainingProvider;
        }
    }
}
