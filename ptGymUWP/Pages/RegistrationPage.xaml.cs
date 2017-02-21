using ptGym_Dal_BL.BL;
using ptGymUWP.ViewModels;
using ptGymUWP.Views;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ptGymUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        RegistrationViewModel RegistrationViewModel { get; set; }
        public RegistrationPage()
        {
            this.InitializeComponent();
            RegistrationViewModel = new RegistrationViewModel();
        }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RegistrationViewModel.Registration = new Registration();
            RegistrationContentDialog pd = new RegistrationContentDialog(RegistrationViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Registration registration = senderElement.DataContext as Registration;

            RegistrationViewModel.Registration = registration;
            RegistrationContentDialog pd = new RegistrationContentDialog(RegistrationViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Registration registration = senderElement.DataContext as Registration;

            RegistrationViewModel.Registration = registration;

            RegistrationViewModel.DeleteRegistration();
        }

        private void StackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        //private void ButtonTeste_Click(object sender, RoutedEventArgs e)
        //{
        //    FrameworkElement senderElement = sender as FrameworkElement;
        //    Registration registration = senderElement.DataContext as Registration;

        //    TextBlockOne.Text = (registration.Ref.ToString());

        //    TextBlockTilte1.Text = ("Valor do Registo:");
        //    TextBlockTwo.Text = (registration.Value.ToString());

        //    TextBlockTilte2.Text = ("Data do Registo:");
        //    string date = registration.Date.ToString("dd-MM-yyyy");
        //    TextBlockThree.Text = (date);

        //    TextBlockTilte3.Text = ("Aula:");
        //    TextBlockFour.Text = (registration.Class.Name);

        //    TextBlockTilte4.Text = ("Cliente:");
        //    TextBlockFive.Text = (registration.Client.Name);
        //}

        private void ButtonTeste_Click(object sender, TappedRoutedEventArgs e)
        {

            FrameworkElement senderElement = sender as FrameworkElement;
            Registration registration = senderElement.DataContext as Registration;  

            TextBlockOne.Text = (registration.Ref.ToString());

            TextBlockTilte1.Text = ("Valor do Registo:");
            TextBlockTwo.Text = (registration.Value.ToString());

            TextBlockTilte2.Text = ("Data do Registo:");
            string date = registration.Date.ToString("dd-MM-yyyy");
            TextBlockThree.Text = (date);

            TextBlockTilte3.Text = ("Aula:");
            TextBlockFour.Text = (registration.Class.Name);

            TextBlockTilte4.Text = ("Cliente:");
            TextBlockFive.Text = (registration.Client.Name);
        }
    }
}
