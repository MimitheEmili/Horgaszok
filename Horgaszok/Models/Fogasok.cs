namespace Horgaszok.Class
{
    public class Fogasok
    {
        public int Fogasok_Id { get; set; }
        public int Hal_Id { get; set; }
        public int Horgaszok_Id { get; set; }
        public DateTime Datum { get; set; }

        // Navigációs tulajdonságok
        public Halak Hal { get; set; }  // A Halak entitás
        public Horgaszok Horgaszok { get; set; }  // A Horgaszok entitás
    }
}
