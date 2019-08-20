using FeroTransferApp.Models;
using FeroTransferApp.ViewModels.Base;
using FeroTransferApp.Views;
using Prism.Commands;
using Prism.Navigation;

namespace FeroTransferApp.ViewModels
{
    public class ActivityPopupViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private TransferModel _transferModel;
        public ActivityPopupViewModel(INavigationService navigationService)
        { 
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                TransferModel = parameters.GetValue<TransferModel>("transferModel");
            }
        }

        public TransferModel TransferModel
        {
            get => _transferModel;
            set => SetProperty(ref _transferModel, value);
        }
    }
}