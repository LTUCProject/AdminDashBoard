using MidProject.Models.Dto.Response;
using MidProject.Models.Dto.Request;
using MidProject.Models.Dto.Request2;
using Microsoft.JSInterop;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using Admin.Dto_s;
using System.Net.Http.Headers;


namespace Admin.Services
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;
            private readonly IJSRuntime _jsRuntime;

        public AdminService(HttpClient httpClient , IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;

        }


        public async Task AddAuthorizationHeader()
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                return;
            }

            // Delay the call until after the component has rendered
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


        //Client Services//
        public async Task<List<ClientBlazorDto>> GetAllClientsAsync()
        {
            await AddAuthorizationHeader();
            var response = await _httpClient.GetFromJsonAsync<ClientBlazorWrapper>("api/Admins/Clients");

            return response?.Values ?? new List<ClientBlazorDto>(); // Return an empty list if response is null
        }

        public async Task<ClientBlazorDto> GetClientByIdAsync(int id)
        {
            await AddAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<ClientBlazorDto>($"api/Admins/Clients/{id}");
        }

        public async Task DeleteClientAsync(int id)
        {
            await AddAuthorizationHeader();
            await _httpClient.DeleteAsync($"api/Admins/Clients/{id}");
        }
        //Client Services//

        //Provider Services//

        public async Task<List<AllProviderBlazorDto>> GetAllProvidersAsync()
        {
            await AddAuthorizationHeader();
            

            var response = await _httpClient.GetFromJsonAsync<AllProviderBlazorWrapper>("api/Admins/providers");

            return response?.Values ?? new List<AllProviderBlazorDto>(); // Return an empty list if response is null
        }

        public async Task<ProviderBlazorDto> GetProviderByIdAsync(int id)
        {
            await AddAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<ProviderBlazorDto>($"api/Admins/providers/{id}");
        }

        public async Task DeleteProviderAsync(int id)
        {
            await AddAuthorizationHeader();
            await _httpClient.DeleteAsync($"api/Admins/providers/{id}");
        }
        //Provider Services//


        //SubscriptionPlan Services//
        public async Task<List<SubscriptionPlanBlazorDto>> GetAllSubscriptionPlansAsync()
        {
            await AddAuthorizationHeader();

            var response = await _httpClient.GetFromJsonAsync<SubscriptionPlanWrapper>("api/Admins/SubscriptionPlans");

            return response?.Values ?? new List<SubscriptionPlanBlazorDto>(); // Return an empty list if response is null
        }

        public async Task<SubscriptionPlanBlazorDto> GetSubscriptionPlanByIdAsync(int id)
        {
            await AddAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<SubscriptionPlanBlazorDto>($"api/Admins/SubscriptionPlans/{id}");
        }

        public async Task<SubscriptionPlanBlazorDto> CreateSubscriptionPlanAsync(SubscriptionPlanDto subscriptionPlanDto)
        {
            await AddAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync("api/Admins/SubscriptionPlans", subscriptionPlanDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SubscriptionPlanBlazorDto>();
            }

            // Handle non-success status codes
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error creating subscription plan: {errorMessage}");
        }


        public async Task DeleteSubscriptionPlanAsync(int id)
        {
            await AddAuthorizationHeader();
            await _httpClient.DeleteAsync($"api/Admins/SubscriptionPlans/{id}");
        }


        public async Task<List<ClientSubscriptionResponseDto>> GetClientSubscriptionsAsync(int clientId)
        {
            await AddAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<List<ClientSubscriptionResponseDto>>($"api/Admins/Clients/{clientId}/Subscriptions");
        }

        public async Task RemoveClientSubscriptionAsync(int clientSubscriptionId)
        {
            await _httpClient.DeleteAsync($"api/Admins/Subscriptions/{clientSubscriptionId}");
        }
        //SubscriptionPlan Services//


        //Notification Services//
        public async Task AddNotificationForAllClientsAsync(NotificationDto notificationDto)
        {
            await AddAuthorizationHeader();

            // Send a notification to all clients
            var response = await _httpClient.PostAsJsonAsync("api/Admins/Notifications", notificationDto);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send notification to all clients.");
            }
        }
        //Notification Services//


        // ChargingStation Services
        public async Task<List<ChargingStationBlazorDto>> GetAllChargingStationsAsync() // Corrected class name
        {
            await AddAuthorizationHeader();
            var response = await _httpClient.GetFromJsonAsync<ChargingStationBlazorWrapper>("api/Admins/ChargingStations"); // Corrected wrapper class name

            // Return an empty list if response is null
            return response?.Values ?? new List<ChargingStationBlazorDto>();
        }

       

        public async Task DeleteChargingStationAsync(int id)
        {


            await AddAuthorizationHeader();
            await _httpClient.DeleteAsync($"api/Admins/ChargingStations/{id}");
        }
        // ChargingStation Services


        // Vehicle Services //

        public async Task<List<VehicleBlazorDto>> GetAllVehiclesAsync()
        {
            await AddAuthorizationHeader();
            var wrapper = await _httpClient.GetFromJsonAsync<VehicleBlazorWrapper>("api/Admins/Vehicles");
            return wrapper?.Values ?? new List<VehicleBlazorDto>();
        }

        public async Task<VehicleBlazorDto> GetVehicleByIdAsync(int id)
        {
            await AddAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<VehicleBlazorDto>($"api/Admins/Vehicles/{id}");
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await AddAuthorizationHeader();
            await _httpClient.DeleteAsync($"api/Admins/Vehicles/{id}");
        }

        public async Task CreateVehicleAsync(VehicleBlazorDto vehicleDto)
        {
            await AddAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync("api/Admins/Vehicles", vehicleDto);
            response.EnsureSuccessStatusCode();
        }

        // Vehicle Services //

    }
}

