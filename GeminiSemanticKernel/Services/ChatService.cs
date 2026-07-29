using Microsoft.SemanticKernel;

public class ChatService
{
    private readonly Kernel _kernel;

    public ChatService(Kernel kernel)
    {
        _kernel = kernel;
    }

    public async Task<string> AskAsync(string prompt)
    {
        var result = await _kernel.InvokePromptAsync(prompt);

        return result.ToString();
    }
}