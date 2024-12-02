namespace dolgozat_241202_hussy_levente;

internal class Author
{
    public string Keresztnev { get; private set; }
    public string Vezeteknev { get; private set; }
    public Guid AuthorId { get; private set; }

    public Author(string fullName)
    {
        var nevek = fullName.Split(' ');

        if (nevek[0].Length < 3 || nevek[0].Length > 32 || nevek[1].Length < 3 || nevek[1].Length > 32)
        {
            throw new Exception("A név minimum 3 karakter és maximum 32 karakter hosszú lehet");
        }


        Keresztnev = nevek[0];
        Vezeteknev = nevek[1];
        AuthorId = Guid.NewGuid();
    }
}
