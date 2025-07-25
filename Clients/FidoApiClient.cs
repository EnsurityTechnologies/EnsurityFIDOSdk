using FidoClientSdk.Extensions;
using FidoClientSdk.Interfaces;
using FidoClientSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FidoClientSdk.Clients
{
    public class FidoApiClient : IFidoApiClient
    {
        private readonly HttpClient _httpClient;
        public FidoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseResponse> ServerCredentialsRequestAsync(ServerCredentialsDto request)
        {
            return await FidoInternalUtils.CredentialRequest(request);
        }

        public async Task<MakeCredentialResponse> MakeCredentialRequestAsync(MakeCredentialRequest request)
        {
            return await FidoInternalUtils.MakeCredential(request, _httpClient);
        }

        public async Task<BaseResponse> MakeCredentialResponseAsync(MakeCredentialFinishRequest responseData)
        {
            return await FidoInternalUtils.MakeCredentialResp(responseData, _httpClient);
        }

        public async Task<GetAssertionResponse> GetAssertionRequestAsync(GetAssertionRequest requestData)
        {
            return await FidoInternalUtils.GetAssertion(requestData, _httpClient);
        }

        public async Task<BaseResponse> GetAssertionResponseAsync(GetAssertionFinishRequest responseData)
        {
            return await FidoInternalUtils.GetAssertionResp(responseData, _httpClient);
        }
    }
}
