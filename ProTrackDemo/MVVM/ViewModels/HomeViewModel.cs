using ProTrackDemo.Core;
using ProTrackDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.MVVM.ViewModels
{
    public class HomeViewModel : ViewModel
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

        
        public RelayCommand NavigateToRegisterCommand { get; set; }

        public HomeViewModel(INavigationService navigation)
        {
            NavigationService = navigation;
            
            NavigateToRegisterCommand = new RelayCommand(_ => { return true; }, parameter => { NavigationService.NavigateTo<RegisterTrainingViewModel>(); });
        }
    }
}
