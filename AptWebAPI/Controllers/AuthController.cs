using AptWebAPI.Database;
using AptWebAPI.Database.Entity;
using AptWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AptWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApartmanContext _context;
        public AuthController(ApartmanContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<LoginReturnModel>> Login([FromBody] LoginModel model)
        {
            var yonetici = await _context.Yoneticis.Where(y => y.Mail == model.Mail).FirstOrDefaultAsync();

            if (yonetici == null)
            {
                return NotFound(new Error("Kullanıcı Bulunamadı"));
            }

            if(yonetici.Sifre == model.Sifre)
            {
                return new LoginReturnModel() { 
                    Id = yonetici.Id, 
                    Mail = yonetici.Mail, 
                    Ad = yonetici.Ad, 
                    SoyAd = yonetici.SoyAd,
                    Tel = yonetici.Tel,
                    ApartmanId = yonetici.ApartmanId,
                };
            } else
            {
                return NotFound(new Error("Sifre Yanlış"));
            }
             
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] KayitModel model)
        {
            var apartman = new Apartman() { Isim = model.ApartmanAdi };

            await _context.Apartmans.AddAsync(apartman);
            var result = _context.SaveChanges();

            if (result > 0)
            {
                apartman = await _context.Apartmans.OrderByDescending(a => a.Id).FirstOrDefaultAsync();

                var yonetici = new Yonetici()
                {
                    Ad = model.Ad,
                    SoyAd = model.SoyAd,
                    Sifre = model.Sifre,
                    Mail = model.Mail,
                    Tel = model.TelefonNo,
                    ApartmanId = apartman.Id,
                };

                await _context.Yoneticis.AddAsync(yonetici);
                var result1 = _context.SaveChanges();

                if(result1 > 0)
                {
                    return Ok(new Error("Başarılı"));
                }

                return NotFound(new Error("Apartman oluşturuldu ancak yönetici oluşturulmadı"));
            }

            return NotFound(new Error("Apartman Oluşturulamadı"));
        }

    }
}
