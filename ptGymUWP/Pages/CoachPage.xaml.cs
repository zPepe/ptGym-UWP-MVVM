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
    public sealed partial class CoachPage : Page
    {
        CoachViewModel CoachViewModel { get; set; }
        public CoachPage()
        {
            this.InitializeComponent();
            CoachViewModel = new CoachViewModel();
        }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CoachViewModel.Coach = new Coach();
            CoachContentDialog pd = new CoachContentDialog(CoachViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Coach coach = senderElement.DataContext as Coach;

            CoachViewModel.Coach = coach;
            CoachContentDialog pd = new CoachContentDialog(CoachViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Coach coaches = senderElement.DataContext as Coach;
            CoachViewModel.Coach = coaches;

            bool res = CoachViewModel.Coach.CheckClass(coaches.Id);
            string message = "Não remover este Treinador";

            if (res == true)
            {
                MessageDialog msg = new MessageDialog(message);
                await msg.ShowAsync();
            }
            else
                CoachViewModel.DeleteCoach();

        }

        private void StackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        //private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var Coach = (Coach)e.ClickedItem;

        //    TextBlockOne.Text = (Coach.Name);
        //    TextBlockTwo.Text = ("Idade: " + Coach.Age);
        //    TextBlockThree.Text = ("Nº Cartão de Cidadão: " + Coach.CC);
        //}

        //private void ButtonTeste_Click(object sender, RoutedEventArgs e)
        //{
        //    FrameworkElement senderElement = sender as FrameworkElement;
        //    Coach coaches = senderElement.DataContext as Coach;
        //    CoachViewModel.Coach = coaches;

        //    TextBlockOne.Text = (coaches.Name);
        //    TextBlockTilte1.Text = ("Idade do Treinador:");
        //    TextBlockTwo.Text = (coaches.Age.ToString());
        //    TextBlockTilte2.Text = ("Nº Cartão de Cidadão:");
        //    TextBlockThree.Text = (coaches.CC.ToString());
        //}

        private void ButtonTeste_Click(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Coach coaches = senderElement.DataContext as Coach;
            CoachViewModel.Coach = coaches;

            TextBlockOne.Text = (coaches.Name);
            TextBlockTilte1.Text = ("Idade do Treinador:");
            TextBlockTwo.Text = (coaches.Age.ToString());
            TextBlockTilte2.Text = ("Nº Cartão de Cidadão:");
            TextBlockThree.Text = (coaches.CC.ToString());
        }
    }
}
