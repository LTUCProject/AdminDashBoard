using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

namespace Admin.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _jsRuntime;
        private readonly AuthStateService _authStateService;

        public AuthService(HttpClient http, IJSRuntime jsRuntime, AuthStateService authStateService)
        {
            _http = http;
            _jsRuntime = jsRuntime;
            _authStateService = authStateService;
        }

        public async Task<bool> IsLoggedIn()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            return !string.IsNullOrEmpty(token);
        }

        public async Task<bool> IsAdmin()
        {
            var roles = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "roles");
            return !string.IsNullOrEmpty(roles) && roles.Split(',').Contains("Admin");
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            var loginDto = new { userName = username, password = password };

            var response = await _http.PostAsJsonAsync("https://localhost:7080/api/Account/Login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AccountResponse>();
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", result.Token);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "username", username);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "roles", string.Join(",", result.Roles));

                _authStateService.IsLoggedIn = true; // Notify about login

                return new LoginResult { Success = true, Token = result.Token, Roles = result.Roles };
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                return new LoginResult { Success = false, Message = errorResponse?.Message ?? "Login failed. Please try again." };
            }
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "token");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "username");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "roles");

            _authStateService.IsLoggedIn = false; // Notify about logout
        }

        private class AccountResponse
        {
            public string Token { get; set; }
            public List<string> Roles { get; set; }
        }

        private class ErrorResponse
        {
            public string Message { get; set; }
        }

        public class LoginResult
        {
            public bool Success { get; set; }
            public string Token { get; set; }
            public List<string> Roles { get; set; }
            public string Message { get; set; }
        }
    }
}
