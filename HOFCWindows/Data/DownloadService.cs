using HOFCWindows.Constants;
using HOFCWindows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.Data
{
    class DownloadService
    {
        public static async Task<List<Actu>> updateActus()
        {
            List<Actu> actus = await DataDownloader.download<Actu>(ServerConstants.ACTUS_URL, null);
            using (var bddContext = new BddContext())
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
                }
                bddContext.SaveChanges();
            }
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            
            localSettings.Values[typeof(Actu).Name + "SyncDate"] = DateTime.Now.ToString();
            return actus;
        }

        public static async Task<List<Calendrier>> updateCalendrier(string equipe)
        {
            return await DataDownloader.download<Calendrier>(ServerConstants.CALENDRIER_URL[equipe], null);
        }

    }
}
