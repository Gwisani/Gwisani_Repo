using Microsoft.EntityFrameworkCore;
using NS_AssignmentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NS_AssignmentAPI.DataAccess
{

    public class FanSpeedDataAccess
    {
        private readonly FanSpeedsContext _context;

        public FanSpeedDataAccess(FanSpeedsContext context)
        {
            _context = context;
        }
        public async Task<List<FanSpeedStatus>> GetFanSpeedStatus()
        {
            try
            {
                return await _context.FanSpeedStatuses.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FanSpeedStatus> PostFanSpeedStatus(FanSpeedStatus fanSpeedStatus)
        {
            try
            {
                _context.FanSpeedStatuses.Add(fanSpeedStatus);
                await _context.SaveChangesAsync();

                return fanSpeedStatus;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FanSpeedStatus> GetFanSpeedStatusById(long id)
        {
            try
            {
                var fanSpeedStatus = await _context.FanSpeedStatuses.FindAsync(id);
                return fanSpeedStatus;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FanSpeedStatus> DeleteFanSpeedStatus(long id)
        {
            _context.FanSpeedStatuses.Remove(id);
            await _context.SaveChangesAsync();
        }
    }
}
