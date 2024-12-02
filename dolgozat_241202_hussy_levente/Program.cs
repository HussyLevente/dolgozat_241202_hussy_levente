using dolgozat_241202_hussy_levente;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        List<Book> konyvek = new List<Book>();
        var szerzoNevek = new List<string>
        {
            "Karolina Adelle",
            "Vince Gerhard",
            "Hajnal Linda",
            "Kolton Utz",
            "Tekla Jae",
            "Karyn Fredric",
            "Ödön Gábriel",
            "Christina Petra",
            "Liesl Noreen",
            "Rupert Sieghard",
            "Enikő Zétény",
            "Józsua Barbara",
            "Diána Bettina",
            "Eszter Edvárd",
            "Mariska Marika"
        };
        var cimek = new List<string>
        {
            "Az Éjszakai Csillag",
            "Budapesti Régi Álmok",
            "Tiszai Titkok",
            "Pusztai Legendák",
            "A Táncoló Lányok Titka",
            "Der Schatten im Schwarzwald",
            "Märchen aus den Alpen",
            "Placeholder",
            "A Duna Dala",
            "Nordlysens Hemmelighet",
            "Sakura no Uta",
            "The Silent Prairie",
            "A Holdfény Kertje",
            "Echoes of Geschichte",
            "Whispers of the Vistula"
        };


        for (int i = 0; i < 15; i++)
        {
            int szerzoSzam = rnd.Next(1, 4);
            var valasztottSzerzok = szerzoNevek.OrderBy(a => rnd.Next()).Take(szerzoSzam).ToList();
            List<Author> szerzok = valasztottSzerzok.Select(nev => new Author(nev)).ToList();

            string cim = cimek[rnd.Next(cimek.Count)];
            long isbn = new Book(0, null, "", 0, "", 0, 0).GenerateRandomISBN();
            int kiadasEve = rnd.Next(2007, DateTime.Now.Year + 1);
            string nyelv = rnd.NextDouble() < 0.8 ? "magyar" : "angol";
            int keszlet = rnd.Next(0, 100) < 30 ? 0 : rnd.Next(5, 11);
            int ar = rnd.Next(10, 101) * 100;

            konyvek.Add(new Book(isbn, szerzok, cim, kiadasEve, nyelv, keszlet, ar));
        }



        //emuláció
        int teljesEladas = 0;
        int kifogyva = 0;
        int teljes = konyvek.Sum(b => b.Keszlet);

        for (int i = 0; i < 100; i++)
        {
            var keresettKonyv = konyvek[rnd.Next(konyvek.Count)];
            if (!keresettKonyv.hiany())
            {
                keresettKonyv.csokkeno();
                teljesEladas += keresettKonyv.Ar;
            }
            else
            {
                if (rnd.NextDouble() < 0.5)
                {
                    int feltoltes = rnd.Next(1, 11);
                    keresettKonyv.novelo(feltoltes);
                }
                else
                {
                    kifogyva++;
                    konyvek.Remove(keresettKonyv);
                }
            }
        }


        int jelenlegi = konyvek.Sum(b => b.Keszlet);
        int kulonbseg = jelenlegi - teljes;

        Console.WriteLine($"Összes bevétel: {teljesEladas} Ft");
        Console.WriteLine($"Kifogyott könyvek a nagykerből: {kifogyva}");
        Console.WriteLine($"Készletváltozás: {teljes} db - {jelenlegi} db ({kulonbseg})");
    }
}