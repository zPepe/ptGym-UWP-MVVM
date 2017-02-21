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
    public sealed partial class ClassContentDialog : ContentDialog
    {
        ClassViewModel ClassViewModel { get; set; }

        public RoomViewModel RoomViewModel { get; set; }
        public ObservableCollection<Room> rooms = Room.GetAll();

        public CoachViewModel CoachViewModel { get; set; }
        public ObservableCollection<Coach> coaches = Coach.GetAll();

        List<string> typeList = new List<string> { "Yoga", "Dança", "Musculação", "Cardio" };
        public ClassContentDialog()
        {
            this.InitializeComponent();
            ClassViewModel = new ClassViewModel();
        }

        public ClassContentDialog(ClassViewModel pvm)
        {
            this.InitializeComponent();
            ClassViewModel = pvm;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            int year = date.Date.Year; int month = date.Date.Month; int day = date.Date.Day;
            int hour = time.Time.Hours; int min = time.Time.Minutes; int sec = time.Time.Seconds;

            DateTime date_class = new DateTime(year, month, day, hour, min, sec);

            ClassViewModel.Class.Date = date_class;

            ClassViewModel.UpdateClass();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void ComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string selectedValue = (string)cmb.SelectedValue;
            ClassViewModel.Class.Type = selectedValue;
        }

        private void ComboBoxCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            long selectedValue = (long)cmb.SelectedValue;
            ClassViewModel.Class.IdCoach = selectedValue;
        }

        private void ComboBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            long selectedValue = (long)cmb.SelectedValue;
            ClassViewModel.Class.IdRoom = selectedValue;
        }
    }
}
