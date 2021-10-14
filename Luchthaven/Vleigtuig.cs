using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven
{

    public enum VliegStatuse
    {
        OpstijgenAanTeVragen,
        OpstijgenGoedgekeurd,
        Opgestegen

    }
    public class Vleigtuig
    {
        public string Vluchtnummer { get; set; }
        public Baan ToegewezenBaan { get; set; }
        public VliegStatuse Status { get; set; }

        public string StijgOp()
        {
            switch (Status)
            {
                case VliegStatuse.OpstijgenAanTeVragen:
                    return $"Geen toelating :Statuse niet overeenkomsting  OpstijgenGoedgekeurd  :OpstijgenAanTeVragen";
                case VliegStatuse.OpstijgenGoedgekeurd:
                    return $"Opgestijgen toelaten : OpstijgenGoedgekeurd toegewezen aan baan {ToegewezenBaan}";
                case VliegStatuse.Opgestegen:
                    return $"Geen toelating :Statuse niet overeenkomsting  OpstijgenGoedgekeurd  : Opgestegen";
                default:
                    return $"Status : Error";
            }
        }
        public string GeefOmschrijving()
        {
            return $"  Vliegtuig met Vluchtnummer {Vluchtnummer}/ Status {Status}/ is opgestaan in: {ToegewezenBaan}";
        }

    }
}
