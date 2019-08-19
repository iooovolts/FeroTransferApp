using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FeroTransferApp.Models;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {
        private INavigationService NavigationService { get; set; }
        public DelegateCommand NavigateToTransferViewCommand { get; set; }
        public ActivityViewModel(INavigationService navigationService)
        {
            Title = "Activity";
            NavigationService = navigationService;
            NavigateToTransferViewCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync("TransferView",useModalNavigation:false)); ;
        }

        private ObservableCollection<TransferModel> _transfers;

        public ObservableCollection<TransferModel> Transfers
        {
            get => _transfers;
            set => SetProperty(ref _transfers, value);
        }
    }
}
