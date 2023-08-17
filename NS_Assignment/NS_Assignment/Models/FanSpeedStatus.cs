namespace NS_AssignmentAPI.Models
{
    public class FanSpeedStatus
    {
        public long Id { get; set; }
        public int PullCodeId { get; set; } // determine either pull code 1 or 2 is pressed. 
        public string PullFanSpeed { get; set; } // when a code is pulled this will show the new set speed
        public string CurrentFanSpeed { get; set; } // this hold the current speed of the fan. 
    }
}
