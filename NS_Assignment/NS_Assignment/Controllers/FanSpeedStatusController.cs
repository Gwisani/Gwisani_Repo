using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NS_AssignmentAPI.Models;

namespace NS_AssignmentAPI.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FanSpeedStatusController : ControllerBase
    {
        private readonly FanSpeedsContext _context;

        public FanSpeedStatusController(FanSpeedsContext context)
        {
            _context = context;
        }

        // GET: api/FanSpeedStatus
        [HttpGet("Get_FanSpeedStatus")]
        public async Task<ActionResult<IEnumerable<FanSpeedStatus>>> GetFanSpeedStatuses()
        {
          if (_context.FanSpeedStatuses == null)
          {
              return NotFound();
          }
          return await _context.FanSpeedStatuses.ToListAsync();
        }

        // GET: api/FanSpeedStatus/5
        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<FanSpeedStatus>> GetFanSpeedStatus(long id)
        {
          if (_context.FanSpeedStatuses == null)
          {
              return NotFound();
          }
          var fanSpeedStatus = await _context.FanSpeedStatuses.FindAsync(id);

          if (fanSpeedStatus == null)
          {
              return NotFound();
          }

          return fanSpeedStatus;
        }


        // POST: api/FanSpeedStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update_FanSpeedStatus")]
        public async Task<ActionResult<FanSpeedStatus>> PostFanSpeedStatus(FanSpeedStatus fanSpeedStatus)
        {
          if (_context.FanSpeedStatuses == null)
          {
              return Problem("Entity set 'FanSpeedsContext.FanSpeedStatuses'  is null.");
          }
          _context.FanSpeedStatuses.Add(fanSpeedStatus);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetFanSpeedStatus", new { id = fanSpeedStatus.Id }, fanSpeedStatus);
        }

    }
}
