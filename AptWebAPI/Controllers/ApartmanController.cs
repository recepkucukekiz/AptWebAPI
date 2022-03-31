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
    public class ApartmanController : ControllerBase
    {
        private readonly ApartmanContext _context;
        public ApartmanController(ApartmanContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApartmanModel>> Get(int apartmanId)
        {
            var apartman = await _context.Apartmans.Where(a => a.Id == apartmanId).Include(a => a.Daires).FirstOrDefaultAsync();

            if (apartman == null)
            {
                return NotFound();
            }

            var daireList = new List<DaireReturnModel>();

            foreach (var daires in apartman.Daires)
            {
                var temp = _context.Kiracis.FirstOrDefault(i => i.Id == daires.KiraciId);
                daireList.Add(
                    new DaireReturnModel()
                    {
                        Id = daires.Id,
                        Kat = daires.Kat,
                        No = daires.No,
                        ApartmanId = daires.ApartmanId,
                        KiraciId = daires.KiraciId,
                        Kiraci = new KiraciModel()
                        {
                            Id = temp.Id,
                            Ad = temp.Ad,
                            SoyAd = temp.SoyAd,
                            TelefonNo = temp.TelefonNo,
                            Mail = temp.Mail,
                            KiraciMi = temp.KiraciMi,
                        },
                    }    
                );
            }

            return new ApartmanModel()
            {
                Id = apartman.Id,
                Isim = apartman.Isim,
                Daires = daireList,
            };
        }
    }
}
