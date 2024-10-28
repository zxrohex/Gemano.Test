using Microsoft.JSInterop;

namespace Gemano.Test.Core.JSInterop
{
    public class ChromeAIJSInteropBridge
    {
        private readonly IJSRuntime _jsRuntime;

        private IJSObjectReference _aiObject;

        public ChromeAIJSInteropBridge(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> Initialize()
        {
            _aiObject = await _jsRuntime.InvokeAsync<IJSObjectReference>("ai.languageModel.create");

            return true;
        }

        public async Task<string> Prompt(string prompt)
        {
            return await _aiObject.InvokeAsync<string>("prompt", prompt);
        }
    }
}
