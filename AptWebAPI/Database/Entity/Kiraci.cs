namespace AptWebAPI.Database.Entity
{
    public class Kiraci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string TelefonNo { get; set; }
        public string Mail { get; set; }
        public bool KiraciMi { get; set; }
        public Daire Daire { get; set; }
    }
}
