using ptGymUWP.Pages;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ptGymUWP { 

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        DispatcherTimer dT = new DispatcherTimer();

        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(MainPage1));
            TitleTextBlock.Text = "Ginásio";

            DateTimeUpdate();

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        /// <summary>
        /// Navegação com o Back Button usando o MyFrame, definido na MainPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    MyFrame.CanGoBack ?
                    AppViewBackButtonVisibility.Visible :
                    AppViewBackButtonVisibility.Collapsed;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                e.Handled = true;
                MyFrame.GoBack();
            }
        }

        /// <summary>
        /// Update do DateTime
        /// </summary>
        void DateTimeUpdate()
        {
            dT.Tick += new EventHandler<object>(dT_Click);
            dT.Interval = new TimeSpan(0, 0, 0);
            dT.Start();
        }

        private void dT_Click(object sender, object e)
        {
            CultureInfo pt = new CultureInfo("pt-PT");
            DateTimeTextBlock.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", pt);
            DateTimeTextBlock2.Text = DateTime.Now.ToString("HH:mm:ss", pt);
        }


        /// <summary>
        /// Navegação para as pages, ao carregar num determinado ListBoxItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox.IsSelected)
            {
                MyFrame.Navigate(typeof(MainPage1));
                TitleTextBlock.Text = "Ginásio";    
            }

            else
                if (ClassListBox.IsSelected)
            {
                MyFrame.Navigate(typeof(ClassPage));
                TitleTextBlock.Text = "Aulas";
            }

            else
                if (ClientListBox.IsSelected)
            {
                MyFrame.Navigate(typeof(ClientPage));
                TitleTextBlock.Text = "Clientes";
            }

            else
                if (CoachListBox.IsSelected)
            {
                MyFrame.Navigate(typeof(CoachPage));
                TitleTextBlock.Text = "Treinadores";
            }

            else
                if (RegistrationListBox.IsSelected)
            {
                MyFrame.Navigate(typeof(RegistrationPage));
                TitleTextBlock.Text = "Registros";
            }

            else
                if (RoomListBox.IsSelected)
            {
                MyFrame.Navigate(typeof(RoomPage));
                TitleTextBlock.Text = "Salas";
            }
            
            else
                if (MenuIniciarListBox.IsSelected)
             {
                SplitView.IsPaneOpen = false;
                MyFrame.Navigate(typeof(MainPage1));
                TitleTextBlock.Text = "Ginásio";
            }
        }

        /// <summary>
        /// Abertura da SplitView, ao carregar "AppBarButton"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        List<string> _listSuggestion = null;
        private void Control2_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {     

            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> _nameList = new List<string>();
                _nameList.Add("Aulas");
                _nameList.Add("Clientes");
                _nameList.Add("Salas");
                _nameList.Add("Treinadores");
                _nameList.Add("Registos");
                _nameList.Add("Funcionalidades");
                _listSuggestion = _nameList.Where(x => x.Contains(sender.Text)).ToList();
                sender.ItemsSource = _listSuggestion;
            }
        }


        private void Control2_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            
            if (selectedItem == "Aulas")
            {
                MyFrame.Navigate(typeof(ClassPage));
            }

            else if (selectedItem == "Clientes")
            {                                                                         
                MyFrame.Navigate(typeof(ClientPage));
            }

            else if (selectedItem == "Treinadores")
            {
                MyFrame.Navigate(typeof(CoachPage));
            }

            else if (selectedItem == "Salas")
            {
                MyFrame.Navigate(typeof(RoomPage));
            }

            else if (selectedItem == "Registos")
            {
                MyFrame.Navigate(typeof(RegistrationPage));
            }

            else if (selectedItem == "Funcionalidades")
            {
                MyFrame.Navigate(typeof(MainPage1));
            }

        }

        private void Control2_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if(args.ChosenSuggestion != null)
            {
                Control2.Text = args.ChosenSuggestion.ToString();
            }
        }


        private void DateTimeTextBlock2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CalendarDatePicker arrivalCalendarDatePicker = new CalendarDatePicker();
            arrivalCalendarDatePicker.Header = "Arrival date";
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mySong.Play();
            Playing.Text = "Now playing...";
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mySong.Pause();
            Playing.Text = "Paused...";
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mySong.Stop();
            Playing.Text = "Stopped...";
        }

        private void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            mySong.Position = mySong.Position - TimeSpan.FromSeconds(10);
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            mySong.Position = mySong.Position + TimeSpan.FromSeconds(10);
        }
    }
}
