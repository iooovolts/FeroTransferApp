using FeroTransferApp.Models;
using FeroTransferApp.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class RecipientsViewModel : BaseViewModel
    {
        private INavigationService _navigationService { get; set; }
        public DelegateCommand AddRecipientCommand { get; set; }
        public DelegateCommand<Recipient> DeleteRecipientCommand { get; set; }

        public RecipientsViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            Title = "Recipients"; 
            RecipientsVisible = true;
            _navigationService = navigationService;
            eventAggregator.GetEvent<RecipientAddedEvent>().Subscribe(AddRecipient);
            DeleteRecipientCommand = new DelegateCommand<Recipient>(DeleteRecipient);
            AddRecipientCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("RecipientDetailView", useModalNavigation: false));
        }

        private void AddRecipient(Recipient recipient)
        {
            Recipients.Add(recipient);
        }

        private void DeleteRecipient(Recipient recipient)
        {
            Recipients.Remove(recipient);
        }

        private async void ViewRecipientDetail(Recipient recipient)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("recipient", recipient);
            await _navigationService.NavigateAsync("RecipientDetailView", navigationParams, false);
        }

        private void FilterRecipientView(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                RecipientsVisible = false;
                FilteredRecipientsVisible = true;
                var searchResult = Recipients.Where(x => x.FullName.ToLower().Contains(value.ToLower()));
                FilteredRecipients = new ObservableCollection<Recipient>(searchResult);
            }
            else
            {
                RecipientsVisible = true;
                FilteredRecipientsVisible = false;
            }
        }

        public string Query
        {
            set { FilterRecipientView(value); }
        }

        private Recipient _recipient;
        public Recipient Recipient
        {
            get => _recipient;
            set
            {
                if (value != null)
                    ViewRecipientDetail(value);
            }
        }

        private ObservableCollection<Recipient> _recipients = new ObservableCollection<Recipient>
        {
            new Recipient { FirstName="Steve"},
            new Recipient { FirstName="Hurley"},
            new Recipient { FirstName="Britney"},
            new Recipient { FirstName="Mustafe"},
            new Recipient { FirstName="Aaron"}
        };
        public ObservableCollection<Recipient> Recipients
        {
            get => _recipients;
            set { SetProperty(ref _recipients, value); }
        }

        private ObservableCollection<Recipient> _filteredRecipients = new ObservableCollection<Recipient>();
        public ObservableCollection<Recipient> FilteredRecipients
        {
            get => _filteredRecipients;
            set { SetProperty(ref _filteredRecipients, value); }
        }

        private bool _recipientsVisible;
        public bool RecipientsVisible
        {
            get => _recipientsVisible;
            set { SetProperty(ref _recipientsVisible, value); }
        }

        private bool _filteredRecipientsVisible;
        public bool FilteredRecipientsVisible
        {
            get => _filteredRecipientsVisible;
            set { SetProperty(ref _filteredRecipientsVisible, value); }
        }
    }
}
