using Microsoft.Extensions.Options;
using System.Net;
using TechGamer.Core.Communication;
using TechGamer.Web.Models;

namespace TechGamer.Web.Services
{
    public interface IClientService
    {
        Task<AddressViewModel> GetAddress(Guid clientId);
        Task<ResponseResult> SetAddress(AddressViewModel addressViewModel, Guid clientId);
    }

    public class ClientService : Service, IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.Url);
        }

        public async Task<AddressViewModel> GetAddress(Guid clientId)
        {
            var response = await _httpClient.GetAsync($"/api/v1/client/address/{clientId}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            HandleErrosResponse(response);

            return await DeserializeObjectResponse<AddressViewModel>(response);
        }

        public async Task<ResponseResult> SetAddress(AddressViewModel addressViewModel,
            Guid clientId)
        {
            var addressContent = GetContent(addressViewModel);

            var response = await _httpClient.PostAsync($"/api/v1/client/set-address-client/" +
                $"{clientId}", addressContent);

            if (!HandleErrosResponse(response))
            {
                return await DeserializeObjectResponse<ResponseResult>(response);
            }

            return ReturnOk();
        }
    }
}
