using ProTrackDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.Services
{
    public interface INavigationService
    {
        ViewModel CurrentViewModel { get; }

        void NavigateTo<T>() where T : ViewModel;
    }
}
