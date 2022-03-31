using AptWebAPI.Database.Entity;

namespace AptWebAPI.Model
{
    public class DaireReturnModel
    {
        public int Id { get; set; }
        public short Kat { get; set; }
        public int No { get; set; }
        public int ApartmanId { get; set; }
        public int KiraciId { get; set; }
        public KiraciModel Kiraci { get; set; }
    }
}
