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
    public sealed partial class CoachContentDialog : ContentDialog
    {
        CoachViewModel CoachViewModel { get; set; }
        public CoachContentDialog()
        {
            this.InitializeComponent();
            CoachViewModel = new CoachViewModel();
        }

        public CoachContentDialog(CoachViewModel pvm)
        {
            this.InitializeComponent();
            CoachViewModel = pvm;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            CoachViewModel.UpdateCoach();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
