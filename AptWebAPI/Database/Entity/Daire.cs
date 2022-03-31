namespace AptWebAPI.Database.Entity
{
    public class Daire
    {
        public int Id { get; set; }
        public short Kat { get; set; }
        public int No { get; set; }
        public Apartman Apartman { get; set; }
        public int ApartmanId { get; set; }
        public Kiraci Kiraci { get; set; }
        public int KiraciId { get; set; }
        public List<Aidat> AidatList { get; set; }
    }
}
