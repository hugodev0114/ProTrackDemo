using ProTrackDemo.Core;
using ProTrackDemo.DbContexts;
using ProTrackDemo.MVVM.Models;
using ProTrackDemo.Services;
using ProTrackDemo.Services.DatabaseServices;
using ProTrackDemo.Services.TrainingCreators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.ViewModels
{
    public class TrackTrainingViewModel : ViewModel
    {
        private readonly ITrainingServiceProvider _trainingServiceProvider;
        private readonly ITrainingCreator _trainingServiceCreator;
        private DbContextFactory _dbContextFactory;
        private const string CONNECTION_STRING = "Data Source=protrack.db";

        private TrainingViewModel _trainingViewModel;

        public RelayCommand DeleteTrainingCommand { get; set; }
        public TrainingViewModel TrainingViewModel
        {
            get => _trainingViewModel;
            set
            {
                _trainingViewModel = value;
                OnPropertyChanged(nameof(TrainingViewModel));
            }
        }

        private ObservableCollection<Training> _comboBoxItems;
        public ObservableCollection<Training> ComboBoxItems
        {
            get => _comboBoxItems;
            set
            {
                _comboBoxItems = value;
                OnPropertyChanged(nameof(ComboBoxItems));
            }
        }

        private Training _selectedItem;
        public Training SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                // Ajoutez ici la logique pour afficher la vue spécifique correspondante à l'élément sélectionné.
                // Vous pouvez utiliser une propriété supplémentaire dans le VueModèle pour représenter la vue spécifique actuellement affichée.
                // Lorsque SelectedItem change, mettez à jour cette propriété et déclenchez un événement PropertyChanged pour notifier la vue.

                OnEntrainementSelectionChanged();
            }
        }

        public TrackTrainingViewModel()
        {

            DeleteTrainingCommand = new RelayCommand(_ => { return true; }, parameter => { DeleteTraining(); });

            _dbContextFactory = new DbContextFactory(CONNECTION_STRING);
            _trainingServiceProvider = new DatabaseTrainingProvider(_dbContextFactory);
            _trainingServiceCreator = new DatabaseTrainingCreator(_dbContextFactory);
            ComboBoxItems = new ObservableCollection<Training>();



            LoadTrainings();

            // Combox sera remplie avec le DatabaseServiceProvider

        }

        private async Task LoadTrainings()
        {
            IEnumerable<Training> trainingCollection = await _trainingServiceProvider.GetAllTrainingsWithExercises();

            foreach (var training in trainingCollection)
            {
                ComboBoxItems.Add(training);
            }
        }

        private async void DeleteTraining()
        {
            if (SelectedItem != null)
            {
                await _trainingServiceCreator.DeleteTraining(SelectedItem.Id);

                ComboBoxItems.Remove(SelectedItem);
            }
        }

        private void OnEntrainementSelectionChanged()
        {
            TrainingViewModel = new TrainingViewModel();

            if (SelectedItem != null)
            {                
                TrainingViewModel.SelectedTraining = SelectedItem;
            }
        }

    }
}

