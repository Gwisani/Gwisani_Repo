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
            string baseUrl = "http://localhost:2030/"; // Replace with your API's base URL
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
    }
}