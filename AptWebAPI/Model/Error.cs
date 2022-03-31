namespace AptWebAPI.Model
{
    public class Error
    {
        public Error(string msg)
        {
            this.Hata = msg;
        }
        public string Hata { get; set; }
    }
}
