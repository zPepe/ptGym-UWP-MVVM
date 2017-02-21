using ptGymUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ptGymUWP.Views
{
    public sealed partial class ClientContentDialog : ContentDialog
    {
        public ClientViewModel ClientViewModel { get; set; }
        public ClientContentDialog()
        {
            this.InitializeComponent();
            ClientViewModel = new ClientViewModel();
        }

        public ClientContentDialog(ClientViewModel pvm)
        {
            this.InitializeComponent();
            ClientViewModel = pvm;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ClientViewModel.UpdateClient();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
