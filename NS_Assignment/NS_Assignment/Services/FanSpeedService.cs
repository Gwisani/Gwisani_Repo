using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NS_AssignmentAPI.DataAccess;
using NS_AssignmentAPI.Models;
using System.Collections.Generic;

namespace NS_AssignmentAPI.Services
{
    public class FanSpeedService
    {
        private readonly FanSpeedsContext _context;
        public FanSpeedService(FanSpeedsContext context)
        {
            _context = context;
        }

        public async Task<List<CheckLastFanSpeed>> GetFanSpeedStatus()
        {
            FanSpeedDataAccess da = new FanSpeedDataAccess(_context);

            try
            {
                List<CheckLastFanSpeed> checkLastFanSpeed = new List<CheckLastFanSpeed>();
                List<FanSpeedStatus> fanSpeedStatuses = await da.GetFanSpeedStatus();

                if (fanSpeedStatuses != null)
                {
                    checkLastFanSpeed[0].LastPullCodeId = fanSpeedStatuses[0].PullCodeId;
                    checkLastFanSpeed[0].LastFanSpeed = fanSpeedStatuses[0].PullFanSpeedRequest;
                }

                return checkLastFanSpeed;
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

        
    }
}
