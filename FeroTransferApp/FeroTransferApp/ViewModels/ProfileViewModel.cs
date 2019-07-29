using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public ProfileViewModel(INavigationService navigationService)
        {
            Title = "Profile";
            _navigationService = navigationService;
        }
    }
}
