using Microsoft.AspNetCore.Mvc;

public class ChatController : Controller
{
    private readonly ChatService _service;

    public ChatController(ChatService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ask(string prompt)
    {
        ViewBag.Answer = await _service.AskAsync(prompt);
        return View("Index");
    }
}