using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;
using Prism.Events;

namespace FeroTransferApp.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {
        private INavigationService NavigationService { get; set; }
        private ObservableCollection<TransferModel> _transferModels = new ObservableCollection<TransferModel>();

        public ActivityViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            Title = "Activity";
            NavigationService = navigationService;
            eventAggregator.GetEvent<TransferCompletedEvent>().Subscribe(AddTransferModel);
        }

        private void AddTransferModel(TransferModel transferModel)
        {
            TransferModels.Add(transferModel);
        }

        public ObservableCollection<TransferModel> TransferModels
        {
            get => _transferModels;
            set => SetProperty(ref _transferModels, value);
        }
    }
}
