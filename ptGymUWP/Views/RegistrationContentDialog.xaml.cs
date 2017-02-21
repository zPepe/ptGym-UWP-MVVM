using ptGym_Dal_BL.BL;
using ptGymUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class RegistrationContentDialog : ContentDialog
    {
        RegistrationViewModel RegistrationViewModel { get; set; }

        public ClientViewModel ClientViewModel { get; set; }
        public ObservableCollection<Client> clients = Client.GetAll();

        public ClassViewModel ClassViewModel { get; set; }
        public ObservableCollection<Class> classes = Class.GetAll();

        public RegistrationContentDialog()
        {
            this.InitializeComponent();
            RegistrationViewModel = new RegistrationViewModel();
        }


        public RegistrationContentDialog(RegistrationViewModel pvm)
        {
            this.InitializeComponent();
            RegistrationViewModel = pvm;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            int year = date.Date.Year; int month = date.Date.Month; int day = date.Date.Day;
            int hour = time.Time.Hours; int min = time.Time.Minutes; int sec = time.Time.Seconds;

            DateTime date_registration = new DateTime(year, month, day, hour, min, sec);

            RegistrationViewModel.Registration.Date = date_registration;

            RegistrationViewModel.UpdateRegistration();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ComboBoxClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            long selectedValue = (long)cmb.SelectedValue;
            RegistrationViewModel.Registration.IdClient = selectedValue;
        }

        private void ComboBoxClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            long selectedValue = (long)cmb.SelectedValue;
            RegistrationViewModel.Registration.IdClass = selectedValue;
        }
    }
}
