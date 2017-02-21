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
    public sealed partial class RoomPage : Page
    {
        RoomViewModel RoomViewModel { get; set; }
        public RoomPage()
        {
            this.InitializeComponent();
            RoomViewModel = new RoomViewModel();
        }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RoomViewModel.Room = new Room();
            RoomContentDialog pd = new RoomContentDialog(RoomViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Room room = senderElement.DataContext as Room;

            RoomViewModel.Room = room;
            RoomContentDialog pd = new RoomContentDialog(RoomViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Room rooms = senderElement.DataContext as Room;
            RoomViewModel.Room = rooms;

            bool res = RoomViewModel.Room.CheckClass(rooms.Id);
            string message = "Não remover esta Sala";

            if (res == true)
            {
                MessageDialog msg = new MessageDialog(message);
                await msg.ShowAsync();
            }
            else
                RoomViewModel.DeleteRoom();

        }

        private void StackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        //private void ButtonTeste_Click(object sender, RoutedEventArgs e)
        //{
        //    FrameworkElement senderElement = sender as FrameworkElement;
        //    Room rooms = senderElement.DataContext as Room;
        //    RoomViewModel.Room = rooms;

        //    TextBlockOne.Text = (rooms.Name);

        //    TextBlockTilte1.Text = ("Capacidade da Sala:");
        //    TextBlockTwo.Text = (rooms.Capacity.ToString());
        //}

        private void ButtonTeste_Click(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Room rooms = senderElement.DataContext as Room;
            RoomViewModel.Room = rooms;

            TextBlockOne.Text = (rooms.Name);

            TextBlockTilte1.Text = ("Capacidade da Sala:");
            TextBlockTwo.Text = (rooms.Capacity.ToString());
        }
    }
}

