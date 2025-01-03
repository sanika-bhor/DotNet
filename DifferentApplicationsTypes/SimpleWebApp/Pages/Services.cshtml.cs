using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleWebApp.Pages;

public class ServicesModel : PageModel
{
    private readonly ILogger<AboutUsModel> _logger;

    public ServicesModel(ILogger<AboutUsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
