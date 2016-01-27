using HOFCWindows.Constants;
using HOFCWindows.Data;
using HOFCWindows.Models;
using HOFCWindows.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HOFCWindows
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Frame AppFrame { get { return this.MainFrame; } }
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(Accueil));
        }

        private void MenuButtonHamburger_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
        }

        private void MenuButtonActu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Accueil));
        }

        private void MenuButtonCalendar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Views.Calendrier));
        }
    }
}
