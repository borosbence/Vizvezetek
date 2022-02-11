using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VizvezetekAPI.DTOs;
using VizvezetekAPI.Models;

namespace VizvezetekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunkalapokController : ControllerBase
    {
        private readonly vizvezetekContext _context;

        public MunkalapokController(vizvezetekContext context)
        {
            _context = context;
        }

        private MunkalapDto ConvertToMunkalapDto(munkalap munkalap)
        {
            if (munkalap == null)
            {
                return null;
            }
            return new MunkalapDto()
            {
                id = munkalap.id,
                beadas_datum = munkalap.beadas_datum,
                javitas_datum = munkalap.javitas_datum,
                helyszin = munkalap.hely.telepules + ", " + munkalap.hely.utca,
                szerelo = munkalap.szerelo.nev,
                munkaora = munkalap.munkaora,
                anyagar = munkalap.anyagar
            };
        }

        // GET: api/Munkalapok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MunkalapDto>>> Getmunkalapok()
        {
            var munkalapok = await _context.munkalap
                .Include(h => h.hely)
                .Include(s => s.szerelo)
                .ToListAsync();

            return munkalapok.Select(m => ConvertToMunkalapDto(m)).ToList();
        }

        // GET: api/Munkalapok/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MunkalapDto>> Getmunkalap(int id)
        {
            var munkalap = await _context.munkalap
                .Include(h => h.hely)
                .Include(s => s.szerelo)
                .FirstOrDefaultAsync(m => m.id == id);

            if (munkalap == null)
            {
                return NotFound();
            }

            return ConvertToMunkalapDto(munkalap);
        }

        // POST: api/Munkalapok/Kereses
        [HttpPost]
        [Route("Kereses")]
        public async Task<ActionResult<IEnumerable<MunkalapDto>>> Kereses(MunkalapKeresesDto kereses)
        {
            var munkalapok = await _context.munkalap
                .Include(h => h.hely)
                .Include(s => s.szerelo)
                .Where(m => m.hely_id == kereses.hely_id && m.szerelo_id == kereses.szerelo_id)
                .ToListAsync();

            return munkalapok.Select(m => ConvertToMunkalapDto(m)).ToList();
        }
    }
}
