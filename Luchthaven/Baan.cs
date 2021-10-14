using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven
{
    public class Baan
    {
        public string Code { get; set; }
        public bool Vrij { get; set; }



        public string GeefOmschrijving()
        {
            return $"De baan code is {Code} en De baan is {(Vrij ? "ja" : "nee")}";

        }
    }

}
