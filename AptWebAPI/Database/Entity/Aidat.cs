namespace AptWebAPI.Database.Entity
{
    public class Aidat
    {
        public int Id { get; set; }
        public double Tutar { get; set; }
        public bool OdendiMi { get; set; }
        public string Donem { get; set; }
        public int DaireId { get; set; }
        public Daire Daire { get; set; }
    }
}
