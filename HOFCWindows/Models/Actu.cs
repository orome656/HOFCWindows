using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.Models
{
    class Actu: IModel
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Titre { get; set; }
        public string Texte { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public DateTime Date { get; set; }
    }
}
