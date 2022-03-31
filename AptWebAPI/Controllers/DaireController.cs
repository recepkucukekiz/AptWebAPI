using AptWebAPI.Database;
using AptWebAPI.Database.Entity;
using AptWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AptWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaireController : ControllerBase
    {
        private readonly ApartmanContext _context;
        public DaireController(ApartmanContext context)
        {
            _context = context;
        }

        // GET: api/Daires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DaireModel>> GetDaire(int id)
        {
            var daire = await _context.Daires.Where(d => d.Id == id).Include(d => d.AidatList).Include(d => d.Kiraci).FirstOrDefaultAsync();

            if (daire == null)
            {
                return NotFound();
            }

            return new DaireModel()
            {
                Id = daire.Id,
                Kat = daire.Kat,
                No = daire.No,
                Kiraci = new KiraciModel()
                {
                    Id = daire.Kiraci.Id,
                    Ad = daire.Kiraci.Ad,
                    SoyAd = daire.Kiraci.SoyAd,
                    Mail = daire.Kiraci.Mail,
                    TelefonNo = daire.Kiraci.TelefonNo,
                    KiraciMi = daire.Kiraci.KiraciMi,
                },
                AidatList = daire.AidatList,
            };
        }

        // POST: api/Daires
        [HttpPost]
        public async Task<ActionResult<DaireReturnModel>> PostDaire(DaireKayitModel model)
        {
            await _context.Kiracis.AddAsync(new Kiraci()
                {
                    Ad = model.KiraciAd,
                    SoyAd = model.KiraciSoyAd,
                    TelefonNo = model.KiraciTelefonNo,
                    Mail = model.KiraciMail,
                    KiraciMi = model.KiraciMi,
                }
            );
            await _context.SaveChangesAsync();

            var kiraci = await _context.Kiracis.OrderByDescending(a => a.Id).FirstOrDefaultAsync();
            var daire = new Daire()
            {
                Kat = model.Kat,
                No = model.No,
                ApartmanId = model.ApartmanId,
                KiraciId = kiraci.Id,
            };

            await _context.Daires.AddAsync(daire);
            await _context.SaveChangesAsync();

            return new DaireReturnModel()
            {
                Id = daire.Id,
                Kat = daire.Kat,
                No = daire.No,
                ApartmanId = daire.ApartmanId,
                KiraciId = daire.KiraciId,
                Kiraci = new KiraciModel()
                {
                    Id = kiraci.Id,
                    Ad = kiraci.Ad,
                    SoyAd = kiraci.SoyAd,
                    TelefonNo = kiraci.TelefonNo,
                    Mail = kiraci.Mail,
                    KiraciMi = kiraci.KiraciMi,
                }
            };
        }
    }
}
