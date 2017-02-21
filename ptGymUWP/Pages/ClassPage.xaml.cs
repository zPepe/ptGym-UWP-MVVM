using ptGym_Dal_BL.BL;
using ptGymUWP.ViewModels;
using ptGymUWP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
    public sealed partial class ClassPage : Page
    {
        ClassViewModel ClassViewModel { get; set; }
        public ClassPage()
        {
            this.InitializeComponent();
            ClassViewModel = new ClassViewModel();
        }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {            
            ClassViewModel.Class = new Class();
            ClassContentDialog pd = new ClassContentDialog(ClassViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Class class1 = senderElement.DataContext as Class;

            ClassViewModel.Class = class1;
            ClassContentDialog pd = new ClassContentDialog(ClassViewModel);
            ContentDialogResult cdr = await pd.ShowAsync();
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Class class1 = senderElement.DataContext as Class;
            ClassViewModel.Class = class1;

            bool res = ClassViewModel.Class.CheckRegistration(class1.Id);
            string message = "Não pode remover esta Aula";

            if (res == true)
            {    
                MessageDialog msg = new MessageDialog(message);
                await msg.ShowAsync();
            }
            else
                ClassViewModel.DeleteClass();
        }

        private void StackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }
    

        private void ButtonTeste_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            Class class1 = senderElement.DataContext as Class;
            ClassViewModel.Class = class1;


            TextBlockOne.Text = (class1.Name);

            TextBlockTilte1.Text = ("Tipo de Aula:");
            TextBlockTwo.Text = (class1.Type);

            TextBlockTilte2.Text = ("Data da Aula:");
            string date = class1.Date.ToString("dd-MM-yyyy");
            TextBlockThree.Text = (date);

            TextBlockTilte3.Text = ("Preço da Aula:");
            TextBlockFour.Text = (class1.Price + " Euros");

            TextBlockTilte4.Text = ("Sala:");
            TextBlockFive.Text = (class1.Room.Name);

            TextBlockTilte5.Text = ("Treinador:");
            TextBlockSix.Text = (class1.Coach.Name);

        }
    }   
}
