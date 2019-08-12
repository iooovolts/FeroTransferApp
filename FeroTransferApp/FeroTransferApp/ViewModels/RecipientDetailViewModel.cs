using FeroTransferApp.Models;
using FeroTransferApp.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class RecipientDetailViewModel : BaseViewModel, INavigatedAware
    {
        private IEventAggregator EventAggregator { get; set; }
        private INavigationService NavigationService { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand TransferCommand { get; set; }
        public RecipientDetailViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            NavigationService = navigationService;
            SaveCommand = new DelegateCommand(SaveRecipient);
        }

        private void SaveRecipient()
        {
            Recipient.IsSaved = true;
            EventAggregator.GetEvent<RecipientAddedEvent>().Publish(Recipient);
            NavigationService.GoBackToRootAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.Count > 0 )
                Recipient = parameters.GetValue<Recipient>("recipient");
        }

        private Recipient _recipient = new Recipient();
        public Recipient Recipient { get => _recipient; set => SetProperty(ref _recipient, value); }
    }
}
