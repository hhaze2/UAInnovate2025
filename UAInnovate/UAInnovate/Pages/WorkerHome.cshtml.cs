using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

//[Authorize]
namespace UAInnovate.Pages
{
    public class WorkerHome : PageModel
    {
        private readonly ILogger<WorkerHome> _logger;

        public WorkerHome(ILogger<WorkerHome> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}