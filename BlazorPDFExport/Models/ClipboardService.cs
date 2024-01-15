using Microsoft.JSInterop;

namespace BlazorPDFExport.Models
{
    public sealed class ClipboardService(IJSRuntime jsRuntime)
    {
        private readonly IJSRuntime _jsRuntime = jsRuntime;

        public ValueTask<string> ReadTextAsync()
        {
            return _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
        }

        public ValueTask WriteTextAsync(string text)
        {
            return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }

}
