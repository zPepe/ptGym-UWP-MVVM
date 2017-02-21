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
using Windows.UI.Popups;
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
    public sealed partial class ClientPage : Page
    {
        ClientViewModel ClientViewModel { get; set; }
        public ClientPage()
        {
            this.InitializeComponent();
            ClientViewModel = new ClientViewModel();
        }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClientViewModel.Client  = new Client();
            ClientContentDialog pd = new ClientContentDialog(ClientViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Client client = senderElement.DataContext as Client;

            ClientViewModel.Client = client;
            ClientContentDialog pd = new ClientContentDialog(ClientViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Client clients = senderElement.DataContext as Client;
            ClientViewModel.Client = clients;

            bool res = ClientViewModel.Client.CheckRegistration(clients.Id);
            string message = "Não remover este Cliente";

            if (res == true)
            {
                MessageDialog msg = new MessageDialog(message);
                await msg.ShowAsync();
            }
            else
                ClientViewModel.DeleteClient();
        }

        private void StackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        //private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var Client = (Client)e.ClickedItem;

        //    TextBlockOne.Text = (Client.Name);
        //    TextBlockTwo.Text = ("Nº Cartão Cidadão: " + Client.CC);          
        //    TextBlockThree.Text = ("Nº Telemovel: " + Client.Phone);

        //    TextBlockFour.Text = ("Morada: " + Client.HomeAddress);
        //    TextBlockFive.Text = ("Localidade: " + Client.Locality);
        //}

        //private void ButtonTeste_Click(object sender, RoutedEventArgs e)
        //{
        //    FrameworkElement senderElement = sender as FrameworkElement;
        //    Client client = senderElement.DataContext as Client;
        //    ClientViewModel.Client = client;

        //    TextBlockOne.Text = (client.Name);

        //    TextBlockTilte1.Text = ("Nº Cartão Cidadão");
        //    TextBlockTwo.Text = (client.CC.ToString());

        //    TextBlockTilte2.Text = ("Nº Telemovel: ");
        //    TextBlockThree.Text = (client.Phone);

        //    TextBlockTilte3.Text = ("Morada");
        //    TextBlockFour.Text = (client.HomeAddress);

        //    TextBlockTilte4.Text = ("Localidade");
        //    TextBlockFive.Text = (client.Locality);


        //}

        private void ButtonTeste_Click(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Client client = senderElement.DataContext as Client;
            ClientViewModel.Client = client;

            TextBlockOne.Text = (client.Name);

            TextBlockTilte1.Text = ("Nº Cartão Cidadão");
            TextBlockTwo.Text = (client.CC.ToString());

            TextBlockTilte2.Text = ("Nº Telemovel: ");
            TextBlockThree.Text = (client.Phone);

            TextBlockTilte3.Text = ("Morada");
            TextBlockFour.Text = (client.HomeAddress);

            TextBlockTilte4.Text = ("Localidade");
            TextBlockFive.Text = (client.Locality);
        }
    }
}
