using Microsoft.EntityFrameworkCore;

namespace NS_AssignmentAPI.Models
{
    public class FanSpeedsContext: DbContext
    {
        public FanSpeedsContext(DbContextOptions<FanSpeedsContext> options) : base(options)
        {
        }

        public DbSet<FanSpeedStatus> FanSpeedStatuses { get; set; }
    }
}
