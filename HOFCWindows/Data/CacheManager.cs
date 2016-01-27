using HOFCWindows.Constants;
using HOFCWindows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.Data
{
    class CacheManager<T> where T : class, IModel
    {
        public async Task<IQueryable<T>> GetList(Func<Task<List<T>>> download)
        {
            bool needToUpdate = false;
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var values = localSettings.Values[typeof(T).Name + "SyncDate"];
            if (values != null)
            {
                DateTime dateSync = DateTime.Parse((string)values);
                if (dateSync < DateTime.Now.AddDays(-7))
                {
                    needToUpdate = true;
                }
            }
            else
            {
                needToUpdate = true;
            }
            IQueryable<T> query;
            if (!needToUpdate)
            {
                // Get from database
                using (var bddContext = new BddContext())
                {
                    query = bddContext.Set<T>().ToList().AsQueryable();
                }
            }
            else
            {
                // Update database
                query = (await download()).AsQueryable();
            }
            return query;
        }
    }
}
