#nullable enable
using Microsoft.JSInterop;

namespace BlazorClient.Services;

public class ThemeService(IJSRuntime js)
{
    private const string Key = "theme";

    public async Task<bool> IsDarkModeAsync()
    {
        var theme = await js.InvokeAsync<string?>("localStorage.getItem", Key);
        return theme == "dark";
    }

    public async Task SetThemeAsync(bool isDark)
    {
        var value = isDark ? "dark" : "light";
        await js.InvokeVoidAsync("localStorage.setItem", Key, value);
        await js.InvokeVoidAsync("eval", $"document.documentElement.classList.toggle('dark-mode', {isDark.ToString().ToLower()})");
    }

    public async Task ToggleThemeAsync()
    {
        bool isDark = !await IsDarkModeAsync();
        await SetThemeAsync(isDark);
    }
}