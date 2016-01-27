using HOFCWindows.Data;
using HOFCWindows.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.ViewModels
{
    public class ActuViewModel
    {
        CacheManager<Actu> cache = new CacheManager<Actu>();
        private ObservableCollection<Actu> actusObservable;
        public ObservableCollection<Actu> ActusList
        {
            get { return this.actusObservable; }
        }

        public ActuViewModel()
        {
            cache.GetList(DownloadService.updateActus).ContinueWith(result => downloadDone(result));
        }

        private void downloadDone(Task<IQueryable<Actu>> result)
        {
            IQueryable<Actu> query = result.Result;
            actusObservable = new ObservableCollection<Actu>(query.OrderByDescending(item => item.Date).ToList());
        }
    }
}
