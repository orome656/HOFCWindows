using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.Models
{
    class Classement: IModel
    {
        [Key]
        public int Id { get; set; }
        public string Equipe { get; set; }
        public int Joue { get; set; }
        public int Points { get; set; }
        public int Victoire { get; set; }
        public int Nul { get; set; }
        public int Defaite { get; set; }
        public int Bp { get; set; }
        public int Bc { get; set; }
        public int Difference { get; set; }
        public string Categorie { get; set; }
    }
}
