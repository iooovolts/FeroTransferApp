﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;
using Prism.Events;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneySummaryViewModel : BaseViewModel
    {
        private IEventAggregator EventAggregator { get; set; }
        private readonly INavigationService _navigationService;
        private TransferModel _transferModel;

        public DelegateCommand NavigateBackCommand { get; set; }
        public DelegateCommand NavigateToConfirmationViewCommand { get; set; }
        public TransferMobileMoneySummaryViewModel(INavigationService navigationService, IEventAggregator eventAggregator) 
        {
            EventAggregator = eventAggregator;
            _navigationService = navigationService;
            NavigateToConfirmationViewCommand = new DelegateCommand(NavigateToConfirmationView);
            NavigateBackCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync());
        }

        private async void NavigateToConfirmationView()
        {
            SaveTransferModel();
            await _navigationService.NavigateAsync("TransferConfirmationPopupView");
        }

        private void SaveTransferModel()
        {
            TransferModel.CreatedDate = DateTime.Now;
            EventAggregator.GetEvent<TransferCompletedEvent>().Publish(TransferModel);
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
