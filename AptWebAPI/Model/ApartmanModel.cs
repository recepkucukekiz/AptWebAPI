using AptWebAPI.Database.Entity;

namespace AptWebAPI.Model
{
    public class ApartmanModel
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public List<DaireReturnModel> Daires { get; set; }
    }
}
