using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NS_AssignmentAPI;

namespace NS_Assignment.Sites.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NS_AssignmentAPIClient _apiClient;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            string baseUrl = "http://localhost:8080/"; // Docker listening port is 8080
            _apiClient = new NS_AssignmentAPIClient(baseUrl, new HttpClient());

        }

        public async Task OnGet()
        {
            ICollection<CheckLastFanSpeed> checkLastFanSpeed = await _apiClient.GetFanSpeedStatusAsync();
        }

        // Event handler for powerCheckbox change
        [HttpGet]
        public async Task<JsonResult> OnGetOnPowerCheckboxChanged(bool isChecked)
        {
            ICollection<CheckLastFanSpeed> checkLastFanSpeed;
            if (isChecked)
            {
                // Perform actions when checkbox is checked
                 checkLastFanSpeed = await _apiClient.GetFanSpeedStatusAsync();
            }
            else
            {
                // Perform actions when checkbox is unchecked
                return new JsonResult(null); // Or an appropriate response
            }
            return new JsonResult(checkLastFanSpeed);
        }

        [HttpGet]
        public async Task<JsonResult> OnGetOnButtonClickUpdate(string pullCodeId, string currentFanSpeed)
        {
            FanSpeedStatus fanSpeedStatus = new FanSpeedStatus
            {
                PullCodeId = pullCodeId,
                CurrentFanSpeed = currentFanSpeed
            };

            FanSpeedStatus resultSpeedStatus;

            int currentSpeedIndex = Array.IndexOf(new string[] { "S0", "S1", "S2", "S3" }, currentFanSpeed);

            if (pullCodeId == "P1")
            {
                // Increase fan speed
                int nextSpeedIndex = (currentSpeedIndex + 1) % 4;
                fanSpeedStatus.PullFanSpeedRequest = new string[] { "S0", "S1", "S2", "S3" }[nextSpeedIndex];
            }
            else if (pullCodeId == "P2")
            {
                // Decrease fan speed
                int prevSpeedIndex = (currentSpeedIndex + 3) % 4;
                fanSpeedStatus.PullFanSpeedRequest = new string[] { "S0", "S1", "S2", "S3" }[prevSpeedIndex];
            }

            try
            {
                 resultSpeedStatus = await _apiClient.PostFanSpeedStatusAsync(fanSpeedStatus);
            }
            catch (Exception ex)
            {

                throw;
            }

            return new JsonResult(resultSpeedStatus);
        }
    }
}