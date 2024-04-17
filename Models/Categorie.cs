using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Recapitulatif.Models
{
    public class Categorie
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public List<Ouvrage> Ouvrages { get; set; }
    }
}
