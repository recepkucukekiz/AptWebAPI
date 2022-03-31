using AptWebAPI.Database.Entity;

namespace AptWebAPI.Model
{
    public class DaireModel
    {
        public int Id { get; set; }
        public short Kat { get; set; }
        public int No { get; set; }
        public KiraciModel Kiraci { get; set; }
        public List<Aidat> AidatList { get; set; }
    }
}
