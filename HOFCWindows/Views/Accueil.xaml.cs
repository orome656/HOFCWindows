using HOFCWindows.Constants;
using HOFCWindows.Data;
using HOFCWindows.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace HOFCWindows.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Accueil : Page
    {
        
        private ObservableCollection<Actu> actusObservable = new ObservableCollection<Actu>(); 
        public ObservableCollection<Actu> Actus { get { return this.actusObservable;  } }
        private CoreDispatcher dispatcher;

        public Accueil()
        {
            this.InitializeComponent();
            Task download = DataDownloader.download<Actu>(ServerConstants.ACTUS_URL, null);
            download.ContinueWith(result => downloadDone((Task<List<Actu>>)result));
        }

        /// <summary>
        /// When activating the scenario, ensure we have permission from the user to access their microphone, and
        /// provide an appropriate path for the user to enable access to the microphone if they haven't
        /// given explicit permission for it.
        /// </summary>
        /// <param name="e">The navigation event details</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }

        private async void downloadDone(Task<List<Actu>> result)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                List<Actu> actus = result.Result;
                using (BddContext bddContext = new BddContext())
                {
                    foreach (Actu actu in actus)
                    {
                        if (bddContext.Actus.Any(item => actu.PostId == item.PostId))
                        {
                            Actu actuBdd = bddContext.Actus.First(item => actu.PostId == item.PostId);
                            actuBdd.Texte = actu.Texte;
                            actuBdd.Titre = actu.Titre;
                            actuBdd.URL = actu.URL;
                            actuBdd.ImageURL = actu.ImageURL;
                            bddContext.Entry(actuBdd).State = Microsoft.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            bddContext.Actus.Add(actu);
                        }
                        actusObservable.Add(actu);
                    }
                    bddContext.SaveChanges();
                }
            });

        }
    }
}
