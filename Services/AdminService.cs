using MidProject.Models.Dto.Response;
using MidProject.Models.Dto.Request;
using MidProject.Models.Dto.Request2;


namespace Admin.Services
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        //Client Services//
        public async Task<List<ClientResponseDto>> GetAllClientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ClientResponseDto>>("api/Admins/Clients");
        }

        public async Task<ClientResponseDto> GetClientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClientResponseDto>($"api/Admins/Clients/{id}");
        }

        public async Task DeleteClientAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Admins/Clients/{id}");
        }
        //Client Services//

        //Provider Services//

        public async Task<List<ProviderResponseDto>> GetAllProvidersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProviderResponseDto>>("api/Admins/providers");
        }

        public async Task<ProviderResponseDto> GetProviderByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProviderResponseDto>($"api/Admins/providers/{id}");
        }

        public async Task DeleteProviderAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Admins/providers/{id}");
        }
        //Provider Services//


        //SubscriptionPlan Services//
        public async Task<List<SubscriptionPlanResponseDto>> GetAllSubscriptionPlansAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<SubscriptionPlanResponseDto>>("api/Admins/SubscriptionPlans");
        }

        public async Task<SubscriptionPlanResponseDto> GetSubscriptionPlanByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<SubscriptionPlanResponseDto>($"api/Admins/SubscriptionPlans/{id}");
        }

        public async Task<SubscriptionPlanResponseDto> CreateSubscriptionPlanAsync(SubscriptionPlanDto subscriptionPlanDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Admins/SubscriptionPlans", subscriptionPlanDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SubscriptionPlanResponseDto>();
            }

            // Handle non-success status codes
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error creating subscription plan: {errorMessage}");
        }


        public async Task DeleteSubscriptionPlanAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Admins/SubscriptionPlans/{id}");
        }

        public async Task<List<ClientSubscriptionResponseDto>> GetClientSubscriptionsAsync(int clientId)
        {
            return await _httpClient.GetFromJsonAsync<List<ClientSubscriptionResponseDto>>($"api/Admins/Clients/{clientId}/Subscriptions");
        }

        public async Task RemoveClientSubscriptionAsync(int clientSubscriptionId)
        {
            await _httpClient.DeleteAsync($"api/Admins/Subscriptions/{clientSubscriptionId}");
        }
        //SubscriptionPlan Services//
        

        //Notification Services//
        public async Task<List<NotificationResponseDto>> GetClientNotificationsAsync(int clientId)
        {
            return await _httpClient.GetFromJsonAsync<List<NotificationResponseDto>>($"api/Admins/Clients/{clientId}/Notifications");
        }

        public async Task<NotificationDto> AddNotificationAsync(NotificationDto notificationDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Admins/Clients/{notificationDto.ClientId}/Notifications", notificationDto);
            return await response.Content.ReadFromJsonAsync<NotificationDto>();
        }
        //Notification Services//


        //CharginigStation Services//
        public async Task<List<ChargingStationResponseAdminDto>> GetAllChargingStationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ChargingStationResponseAdminDto>>("api/Admins/ChargingStations");
        }

        public async Task<ChargingStationResponseAdminDto> GetChargingStationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ChargingStationResponseAdminDto>($"api/Admins/ChargingStations/{id}");
        }

        public async Task DeleteChargingStationAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Admins/ChargingStations/{id}");
        }

        public async Task CreateChargingStationAsync(ChargingStationDto chargingStationDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Admins/ChargingStations", chargingStationDto);
            response.EnsureSuccessStatusCode();
        }
        //CharginigStation Services//

        //Vehicle Services//

        public async Task<List<VehicleResponseDto>> GetAllVehiclesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<VehicleResponseDto>>("api/Admins/Vehicles");
        }

        public async Task<VehicleResponseDto> GetVehicleByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<VehicleResponseDto>($"api/Admins/Vehicles/{id}");
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Admins/Vehicles/{id}");
        }

        public async Task CreateVehicleAsync(VehicleDto vehicleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Admins/Vehicles", vehicleDto);
            response.EnsureSuccessStatusCode();
        }
        //Vehicle Services//

        //Location Services//
        public async Task<List<LocationResponseDto>> GetAllLocationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LocationResponseDto>>("api/Admins/Locations");
        }

        public async Task<LocationResponseDto> GetLocationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<LocationResponseDto>($"api/Admins/Locations/{id}");
        }

        public async Task CreateLocationAsync(LocationDto locationDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Admins/Locations", locationDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateLocationAsync(int id, LocationDto locationDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Admins/Locations/{id}", locationDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteLocationAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Admins/Locations/{id}");
        }
        //Location Services//



    }
}

