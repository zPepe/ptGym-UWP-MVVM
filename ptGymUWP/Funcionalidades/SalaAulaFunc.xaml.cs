using ptGym_Dal_BL.BL;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ptGymUWP.Funcionalidades
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SalaAulaFunc : Page
    {
        ClassViewModel ClassViewModel { get; set; }
        RoomViewModel RoomViewModel { get; set; }
        public SalaAulaFunc()
        {
            this.InitializeComponent();
            ClassViewModel = new ClassViewModel();
            RoomViewModel = new RoomViewModel();
            ClassViewModel.Classes = Class.GetAll();

            var groups = from t in ClassViewModel.Classes
                         group t by t.Room.Name;
            cvs.Source = groups;
        }

        private void SemanticZoom_ViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            if (e.SourceItem.Item != null)
            {
                e.DestinationItem = new SemanticZoomLocation { Item = e.SourceItem.Item };
            }
        }
    }
}
