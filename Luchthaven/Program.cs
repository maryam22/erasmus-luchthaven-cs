using System;

namespace Luchthaven
{
    class Program
    {
        static void Main(string[] args)
        {
            var controleToren = new ControleToren();

            var flight = new Vleigtuig();
            flight.Vluchtnummer = "ABC123";
            flight.Status = VliegStatuse.Opgestegen;
            var baan = new Baan();
            baan.Code = "ABC";
            baan.Vrij = true;
            flight.ToegewezenBaan = baan;

            controleToren.RegistreerVliegtuig(flight);

            ConsoleKeyInfo input;
            string menu = "Controletorne - menu:\n" +
                "1. Voeg baan toe.\n" +
                "2. Registeer vliegtuig.\n" +
                "3. Controletoren overzicht.\n" +
                "4. Aanvraag voor opstijgen.\n" +
                "5. Opstijgen.\n" +
                "6. Stop.\n" +
                "> ";

            do
            {
                Console.WriteLine(menu);
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Geef de baan code in:");

                        controleToren.Banen.Add(new Baan
                        {
                            Code = Console.ReadLine(),
                            Vrij = true
                        });
                        Console.WriteLine(controleToren.OverzichtBanen());
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Geef de vliegtuig nummer in: ");
                        controleToren.Vliegtuigen.Add(new Vleigtuig
                        {
                            Vluchtnummer = Console.ReadLine(),
                        });
                        Console.WriteLine(controleToren.OverzichtVliegtuigen());
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine(controleToren.OverzichtVliegtuigen());
                        Console.WriteLine(controleToren.OverzichtBanen());
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("Geef het vluchtnummmer in:");
                        var requestTakeOffVluchtnummmer = Console.ReadLine();
                        Console.WriteLine(controleToren.AanvraagTotOpstijgen(requestTakeOffVluchtnummmer));
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.WriteLine("Geef het vluchtnummmer in:");
                        var vluchtnummmer = Console.ReadLine();
                        var vluchtResult = controleToren.ZoekVliegtuig(vluchtnummmer);
                        Console.WriteLine(vluchtResult?.GeefOmschrijving());
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        return;
                    default:
                        break;
                }
            } while (input.Key != ConsoleKey.D6);


        }
    }
}
