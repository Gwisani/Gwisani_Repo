using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NS_AssignmentAPI.Models;
using NS_AssignmentAPI.Services;

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
        [HttpGet("GetFanSpeedStatus")]
        public async Task<ActionResult<IEnumerable<FanSpeedStatus>>> GetFanSpeedStatuses()
        {
            if (_context.FanSpeedStatuses == null)
            {
                return NotFound();
            }
            FanSpeedService fanSpeedService = new FanSpeedService(_context);
            try
            {
                List<FanSpeedStatus> fanSpeedStatus = await fanSpeedService.GetFanSpeedStatus();
                return fanSpeedStatus;
            }
            catch (Exception ex)
            {

                throw;
            }
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

            FanSpeedService fanSpeedService = new FanSpeedService(_context);
            try
            {
                ActionResult<FanSpeedStatus> fanSpeedStatus = await fanSpeedService.GetFanSpeedStatusById( id);
                if (fanSpeedStatus == null)
                {
                    return NotFound();
                }
                return fanSpeedStatus;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        // POST: api/FanSpeedStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostFanSpeedStatus")]
        public async Task<ActionResult<FanSpeedStatus>> PostFanSpeedStatus(FanSpeedStatus fanSpeedStatus)
        {
            if (_context.FanSpeedStatuses == null)
            {
                return Problem("Entity set 'FanSpeedsContext.FanSpeedStatuses'  is null.");
            }
            FanSpeedService fanSpeedService = new FanSpeedService(_context);

            try
            {
                FanSpeedStatus postFanSpeedStatus = await fanSpeedService.PostFanSpeedStatus( fanSpeedStatus);
                return CreatedAtAction("GetFanSpeedStatus", new { id = postFanSpeedStatus.Id }, fanSpeedStatus);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
