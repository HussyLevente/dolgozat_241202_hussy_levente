namespace dolgozat_241202_hussy_levente;

internal class Book
{
    Random rnd = new Random();
    private static long IDSBN = 1000000000;
    private long isbnlong;
    private List<Author> authors;
    private string cim;
    private int kiadasEve;
    private string nyelv;
    private int keszlet;
    private int ar;

    public long ISBN
    {
        get => isbnlong;
        
        private set
        {
            isbnlong = value;
            if (ISBN < 1000000000 || ISBN > 9999999999)
            {
                throw new Exception("ISBN-nek 10 számjegyűnek kell lennie");
            }
        }
    }
    public List<Author> Szerzok
    {
        get => authors;
        
        private set
        {
            authors = value;
            if (Szerzok.Count < 1 || Szerzok.Count > 3)
            {
                throw new Exception("A listában minimum 1 és maximum 3 elem tartozhat");
            }
        }
    }
    public string Cim
    {
        get => cim;

        private set
        {
            cim = value;
            if (Cim.Length < 3 || Cim.Length > 64)
            {
                throw new Exception("A címnek minimum 3 és maximum 64 karakter hosszúnak kell lennie");
            }
        }
    }
    public int KiadasEve
    {
        get => kiadasEve;
        
        private set
        {
            kiadasEve = value;
            if (KiadasEve < 2007 || KiadasEve > DateTime.Now.Year)
            {
                throw new Exception("A kiadás évének 2007 és jelen év közötti egész számnak kell lennie");
            }
        }
    }
    public string Nyelv
    {
        get => nyelv;
        
        private set
        {
            nyelv = value;
            if (Nyelv != "angol" && Nyelv != "német" && Nyelv != "magyar")
            {
                throw new Exception("Csak az angol, német és a magyar elfogadott érték");
            }
        }
    }
    public int Keszlet
    {
        get => keszlet;
        
        private set
        {
            keszlet = value;
            if (Keszlet < 0)
            {
                throw new Exception("A készletnek 0-nál nagyobb egész számnak kell lennie");
            }
        }
    }
    public int Ar
    {
        get => ar;
        
        private set
        {
            ar = value;
            if (Ar < 1000 || Ar > 10000 || Ar % 100 != 0)
            {
                throw new Exception("Az árnak 1000 és 10000 közötti értéknek kell lennie");
            }
        }
    }

    public void szerzohozzaadas(params string[] szerzo)
    {
        foreach (var szerzok in szerzo)
        {
            authors.Add(new(szerzok));
        }
    }

    public Book(long isbn, List<Author> szerzok, string cim, int kiadasEve, string nyelv, int keszlet, int ar)
    {
        ISBN = isbn;
        Szerzok = szerzok;
        Cim = cim;
        KiadasEve = kiadasEve;
        Nyelv = nyelv;
        Keszlet = keszlet;
        Ar = ar;
    }

    public Book(string cim, string szerzoNeve)
    {
        ISBN = GenerateRandomISBN();
        Szerzok = new List<Author> { new Author(szerzoNeve) };
        Cim = cim;
        KiadasEve = 2024;
        Nyelv = "magyar";
        Keszlet = 0;
        Ar = 4500;
    }


    public override string ToString()
    {
        string szerzolista = Szerzok.Count == 1 ? "szerző:" : "szerzők:";
        string beszerzes = Keszlet == 0 ? "beszerzés alatt" : $"{Keszlet} db";
        return $"{Cim} - {szerzolista} {string.Join(", ", Szerzok.Select(a => a.Keresztnev + " " + a.Vezeteknev))}, Készlet: {beszerzes}, Ár: {Ar} Ft";
    }

    public long GenerateRandomISBN()
    {
        long isbn;
        do
        {
            isbn = rnd.Next(1000000000, 1000000000);
        } 
        while (isbn == IDSBN);
        IDSBN = isbn;
        return isbn;
    }

    public void csokkeno()
    {
        if (Keszlet > 0)
        {
            Keszlet--;
        }
    }

    public void novelo(int darab)
    {
        Keszlet += darab;
    }

    public bool hiany()
    {
        return Keszlet == 0;
    }
}
