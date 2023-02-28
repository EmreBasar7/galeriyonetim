using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace galeriyonetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AraclarController : ControllerBase
    {
        
        private readonly DataContext _context;

        public AraclarController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<arac>>> Get()
        {            
            return Ok(await _context.arac.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<arac>> Get(int id)
        {
            var arac = await _context.arac.FindAsync(id);
            if (arac == null)
                return BadRequest("Araç Bulunamadı.");
            return Ok(arac);
        }
        [HttpPost]
        public async Task<ActionResult<List<arac>>> AddArac(arac arac)
        {
            _context.arac.Add(arac);
            await _context.SaveChangesAsync();

            return Ok(await _context.arac.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<arac>>> UpdateArac(arac request)
        {
            var dbArac = await _context.arac.FindAsync(request.Id);
            if (dbArac == null)
                return BadRequest("Araç Bulunamadı.");

            dbArac.AracMarka = request.AracMarka;
            dbArac.AracModel = request.AracModel;
            dbArac.AracYılı = request.AracYılı;

            await _context.SaveChangesAsync();

            return Ok(await _context.arac.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<arac>>> Delete(int id)
        {
            var dbArac = await _context.arac.FindAsync(id);
            if (dbArac == null)
                return BadRequest("Araç Bulunamadı.");

            _context.arac.Remove(dbArac);
            await _context.SaveChangesAsync();

            return Ok(await _context.arac.ToListAsync());

        }



    }
}
