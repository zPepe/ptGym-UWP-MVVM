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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ptGymUWP.Funcionalidades
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClassClientFunc : Page
    {
        ClientViewModel ClientViewModel { get; set; }
        ClassViewModel ClassViewModel { get; set; }
        RegistrationViewModel RegistrationViewModel { get; set; }
        public ClassClientFunc()
        {
            this.InitializeComponent();
            ClientViewModel = new ClientViewModel();
            RegistrationViewModel = new RegistrationViewModel();
            ClassViewModel = new ClassViewModel();
            RegistrationViewModel.Registrations = Registration.GetAll();

            var groups = from t in RegistrationViewModel.Registrations
                         group t by t.Client.Name;
            cvs.Source = groups;
            
        }


        private void SemanticZoom_ViewChangeStarted_1(object sender, SemanticZoomViewChangedEventArgs e)
        {
            if (e.SourceItem.Item != null)
            {
                e.DestinationItem = new SemanticZoomLocation { Item = e.SourceItem.Item };
            }
        }
    }
}
