using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven
{
    public class ControleToren
    {
        public List<Vleigtuig> Vliegtuigen { get; set; }
        public List<Baan> Banen { get; set; }

        public ControleToren()
        {
            Vliegtuigen = new List<Vleigtuig>();
            Banen = new List<Baan>();
        }

        public string RegistreerVliegtuig(Vleigtuig vleigtuig)
        {
            string vluchtnummer = string.Empty;
            Random random = new Random();
            do
            {
                int asciiNr = random.Next(48, 91);
                if (asciiNr >= 58 && asciiNr < 65)
                {
                    continue;
                }
                vluchtnummer += (char)asciiNr;
            }
            while (vluchtnummer.Length < 6);

            return vluchtnummer;
        }

        public Vleigtuig ZoekVliegtuig(string vluchtnummber)
        {
            return Vliegtuigen.Find(v => v.Vluchtnummer == vluchtnummber);
        }

        public string AanvraagTotOpstijgen(string vluchtnummer)
        {
            var flight = ZoekVliegtuig(vluchtnummer);

            if (flight == null)
            {
                return string.Empty;
            }
            return flight.StijgOp();
        }

        public Baan ZoekVrijeBaan()
        {
            return Banen.Where(b => b.Vrij).FirstOrDefault();
        }

        public string OverzichtVliegtuigen()
        {
            return string.Join(", ",
                Vliegtuigen.Select(v =>
            v.GeefOmschrijving().ToString()));
        }

        public string OverzichtBanen()
        {
            return string.Join(", ", Banen.Select(b => b.GeefOmschrijving()));
        }
    }
}
