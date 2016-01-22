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
    public sealed partial class Calendrier : Page
    {

        private ObservableCollection<Models.Calendrier> matchsObservable = new ObservableCollection<Models.Calendrier>();
        public ObservableCollection<Models.Calendrier> Matchs { get { return this.matchsObservable; } }
        private CoreDispatcher dispatcher;

        public Calendrier()
        {
            this.InitializeComponent();
            Task download = DataDownloader.download<Models.Calendrier>(ServerConstants.CALENDRIER_URL["equipe1"], null);
            download.ContinueWith(result => downloadDone((Task<List<Models.Calendrier>>)result));
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


        private async void downloadDone(Task<List<Models.Calendrier>> result)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                List<Models.Calendrier> matchs = result.Result;
                using (BddContext bddContext = new BddContext())
                {
                    foreach (Models.Calendrier match in matchs)
                    {
                        if (bddContext.Calendriers.Any(item => match.Equipe1 == item.Equipe1
                                                                && match.Equipe2 == item.Equipe2
                                                                && match.Categorie == item.Categorie))
                        {
                            Models.Calendrier matchBdd = bddContext.Calendriers.First(item => match.Equipe1 == item.Equipe1
                                                                && match.Equipe2 == item.Equipe2
                                                                && match.Categorie == item.Categorie);
                            matchBdd.Date = match.Date;
                            matchBdd.Score1 = match.Score1;
                            matchBdd.Score2 = match.Score2;
                            bddContext.Entry(matchBdd).State = Microsoft.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            bddContext.Calendriers.Add(match);
                        }
                        matchsObservable.Add(match);
                    }
                    bddContext.SaveChanges();
                }
            });

        }
    }
}
