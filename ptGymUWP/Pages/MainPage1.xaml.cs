using ptGymUWP.Funcionalidades;
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
    public sealed partial class MainPage1 : Page
    {
        public MainPage1()
        {
            this.InitializeComponent();
            Loaded += MainPage1_Loaded;
        }


        void MainPage1_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> sections = new List<string>();

            foreach (HubSection section in myHub.Sections)
            {
                if (section.Header != null)
                {
                    sections.Add(section.Header.ToString());
                }
            }
            ZoomedOutList.ItemsSource = sections;                     
        }


        private void NewsHub_SectionHeaderClick(object sender, HubSectionHeaderClickEventArgs e)
        {
            switch (e.Section.Name)
            {
                case "Funcionalidade1":
                    Frame.Navigate(typeof(ClassClientFunc));
                    break;
                case "Funcionalidade2":
                    Frame.Navigate(typeof(ClientLocalidadeFunc));
                    break;
                case "Funcionalidade3":
                    Frame.Navigate(typeof(TreinadorAulaFunc));
                    break;
                case "Funcionalidade4":
                    Frame.Navigate(typeof(SalaAulaFunc));
                    break;
                default:
                    break;
            }
        }
    }
}
