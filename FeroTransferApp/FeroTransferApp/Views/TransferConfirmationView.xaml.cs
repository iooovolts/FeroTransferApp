﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeroTransferApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferConfirmationView : PopupPage
    {
        public TransferConfirmationView()
        {
            InitializeComponent();
        }
    }
}