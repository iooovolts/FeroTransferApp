using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.ViewModels
{
    public class TopUpViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public TopUpViewModel(INavigationService navigationService)
        {
            Title = "Top Up";
            _navigationService = navigationService;
        }
    }
}
