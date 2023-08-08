using ProTrackDemo.Core;
using ProTrackDemo.MVVM.Models;
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

        private TrainingViewModel _trainingViewModel;
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

            ComboBoxItems = new ObservableCollection<Training>
            {
                new Training
                {
                    Name = "Upper 1",
                    Exercises = new ObservableCollection<Exercise>
                    {
                        new Exercise { Name = "Push-ups" },
                        new Exercise { Name = "Pull-ups" }
                    }
                },
                new Training
                {
                    Name = "Lower 2",
                    Exercises = new ObservableCollection<Exercise>
                    {
                        new Exercise { Name = "Squats" },
                        new Exercise { Name = "Lunges" }
                    }
                },
                new Training
                {
                    Name = "Murph 3.0",
                    Exercises = new ObservableCollection<Exercise>
                    {
                        new Exercise { Name = "Running" },
                        new Exercise { Name = "Push-ups" },
                        new Exercise { Name = "Pull-ups" },
                        new Exercise { Name = "Squats" }
                    }
                }
            };

            
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

