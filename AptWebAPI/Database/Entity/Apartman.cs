namespace AptWebAPI.Database.Entity
{
    public class Apartman
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public Yonetici Yonetici { get; set; }
        public List<Daire> Daires { get; set; }
    }
}
