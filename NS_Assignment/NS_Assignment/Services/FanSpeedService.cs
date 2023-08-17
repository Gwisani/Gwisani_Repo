using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NS_AssignmentAPI.DataAccess;
using NS_AssignmentAPI.Models;

namespace NS_AssignmentAPI.Services
{
    public class FanSpeedService
    {
        private readonly FanSpeedsContext _context;
        public FanSpeedService(FanSpeedsContext context)
        {
            _context = context;
        }

        public async Task<List<FanSpeedStatus>> GetFanSpeedStatus()
        {
            FanSpeedDataAccess da = new FanSpeedDataAccess(_context);

            try
            {
                List<FanSpeedStatus> fanSpeedStatuses = await da.GetFanSpeedStatus();
                return fanSpeedStatuses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FanSpeedStatus> PostFanSpeedStatus( FanSpeedStatus fanSpeedStatus)
        {
            FanSpeedDataAccess da = new FanSpeedDataAccess(_context);
            try
            {
                FanSpeedStatus postFanSpeeds = await da.PostFanSpeedStatus(fanSpeedStatus);
                return postFanSpeeds;

            }
            catch (Exception ex)
            {

                throw;
            };
        }

        public async Task<ActionResult<FanSpeedStatus>> GetFanSpeedStatusById( long id)
        {
            FanSpeedDataAccess da = new FanSpeedDataAccess(_context);
            try
            {
                var fanSpeedStatus = await da.GetFanSpeedStatusById(id);
                return fanSpeedStatus;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FanSpeedStatus> DeleteFanSpeedStatus(ActionResult? id)
        {
            
            FanSpeedDataAccess da = new FanSpeedDataAccess(_context);
            try
            {
                var fanSpeedStatus = await da.DeleteFanSpeedStatus(id);
                return fanSpeedStatus;
            }
            catch (Exception)
            {

                throw;
            }


           

        }
    }
}
