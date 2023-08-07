using ProTrackDemo.Core;
using ProTrackDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.ViewModels
{
    class MainViewModel : ViewModel
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToRegisterCommand { get; set; }
        public RelayCommand NavigateToTrackCommand { get; set; }

        public MainViewModel(INavigationService navigation)
        {
            NavigationService = navigation;
            NavigateToHomeCommand = new RelayCommand(_=> { return true; }, parameter => { NavigationService.NavigateTo<HomeViewModel>(); });
            NavigateToTrackCommand = new RelayCommand(_ => { return true; }, parameter => { NavigationService.NavigateTo<TrackTrainingViewModel>(); });
            NavigateToRegisterCommand = new RelayCommand(_ => { return true; }, parameter => { NavigationService.NavigateTo<RegisterTrainingViewModel>(); });

        }
    }
}
