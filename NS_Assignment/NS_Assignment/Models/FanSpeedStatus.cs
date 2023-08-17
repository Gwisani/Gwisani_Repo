namespace NS_AssignmentAPI.Models
{
    public class FanSpeedStatus
    {
        public long Id { get; set; }
        public string PullCodeId { get; set; } // determine either pull code PC1 or PC2 is pressed. 
        public string PullFanSpeedRequest { get; set; } // when a code is pulled this will show the new set speed
        public string CurrentFanSpeed { get; set; } // this hold the current speed of the fan. 
    }
}
