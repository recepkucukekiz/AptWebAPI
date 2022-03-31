namespace AptWebAPI.Database.Entity
{
    public class Yonetici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public Apartman Apartman { get; set; }
        public int ApartmanId { get; set; }
    }
}
