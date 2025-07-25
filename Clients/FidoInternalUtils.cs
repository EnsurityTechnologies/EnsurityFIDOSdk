using FidoClientSdk.Extensions;
using FidoClientSdk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FidoClientSdk.Clients
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class FidoInternalUtils
    {
        internal static async Task<BaseResponse> CredentialRequest(ServerCredentialsDto request)
        {
            var response = new BaseResponse();

            try
            {
                if (!string.IsNullOrWhiteSpace(request.BaseURL))
                {
                    request.BaseURL = AesEncryption.Encrypt(request.BaseURL);
                }

                if (!string.IsNullOrWhiteSpace(request.ApiKey))
                {
                    request.ApiKey = AesEncryption.Encrypt(request.ApiKey);
                }

                // Define the path to appsettings.json
                var appRoot = AppDomain.CurrentDomain.BaseDirectory;
                var configPath = Path.Combine(appRoot, "appsettings.json");

                Dictionary<string, object> appSettings;

                // Check if appsettings.json exists
                if (File.Exists(configPath))
                {
                    var existingJson = await File.ReadAllTextAsync(configPath);
                    appSettings = JsonSerializer.Deserialize<Dictionary<string, object>>(existingJson)
                                  ?? new Dictionary<string, object>();
                }
                else
                {
                    appSettings = new Dictionary<string, object>();
                }

                appSettings["ServerCredentials"] = request;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = null
                };

                var updatedJson = JsonSerializer.Serialize(appSettings, options);
                await File.WriteAllTextAsync(configPath, updatedJson);
                response.Status = true;
                response.Message = "Server credentials updated successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Failed to update credentials: {ex.Message}";
            }

            return response;
        }

        internal static async Task<MakeCredentialResponse> MakeCredential(MakeCredentialRequest request, HttpClient _httpClient)
        {
            var credentialResp = new MakeCredentialResponse();
            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("appsettings.json"))
                {
                    var credentials = await FidoClientServiceCollectionExtensions.LoadServerCredentialsAsync();
                    if (credentials != null)
                    {
                        _httpClient.BaseAddress = new Uri(credentials.BaseURL);
                        _httpClient.DefaultRequestHeaders.Add("X-AMS-API-Key", credentials.ApiKey);
                    }
                }
                var response = await _httpClient.PostAsJsonAsync("/api/fidomakecredentialrequest", request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<MakeCredentialResponse>();
                if (result == null)
                {
                    credentialResp.Status = false;
                    credentialResp.Message = "Empty response body from server";
                }
                else
                {
                    credentialResp = result;
                }
                return credentialResp;
            }
            catch (Exception ex)
            {
                credentialResp.Status = false;
                credentialResp.Message = ex.Message;
                return credentialResp;
            }
        }

        internal static async Task<BaseResponse> MakeCredentialResp(MakeCredentialFinishRequest responseData, HttpClient _httpClient)
        {
            var baseResp = new BaseResponse();
            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("appsettings.json"))
                {
                    var credentials = await FidoClientServiceCollectionExtensions.LoadServerCredentialsAsync();
                    if (credentials != null)
                    {
                        _httpClient.BaseAddress = new Uri(credentials.BaseURL);
                        _httpClient.DefaultRequestHeaders.Add("X-AMS-API-Key", credentials.ApiKey);
                    }
                }
                var response = await _httpClient.PostAsJsonAsync("/api/fidomakecredentialresponse", responseData);
                if (response.IsSuccessStatusCode)
                {
                    baseResp.Status = true;
                    baseResp.Message = "Credential Created Successfully.";
                }
                else
                {
                    baseResp.Status = false;
                    baseResp.Message = "Credential creation failed.";
                }
                return baseResp;
            }
            catch (Exception ex)
            {
                baseResp.Status = false;
                baseResp.Message = ex.Message;
                return baseResp;
            }
        }

        internal static async Task<GetAssertionResponse> GetAssertion(GetAssertionRequest requestData, HttpClient _httpClient)
        {
            var assertionOptionsResp = new GetAssertionResponse();
            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("appsettings.json"))
                {
                    var credentials = await FidoClientServiceCollectionExtensions.LoadServerCredentialsAsync();
                    if (credentials != null)
                    {
                        _httpClient.BaseAddress = new Uri(credentials.BaseURL);
                        _httpClient.DefaultRequestHeaders.Add("X-AMS-API-Key", credentials.ApiKey);
                    }
                }
                var response = await _httpClient.PostAsJsonAsync("/api/fidogetassertion", requestData);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<GetAssertionResponse>();
                if (result == null)
                {
                    assertionOptionsResp.Status = false;
                    assertionOptionsResp.Message = "Empty response body from server";
                }
                else
                {
                    assertionOptionsResp = result;
                }
                return assertionOptionsResp;
            }
            catch (Exception ex)
            {
                assertionOptionsResp.Status = false;
                assertionOptionsResp.Message = ex.Message;
                return assertionOptionsResp;
            }
        }

        internal static async Task<BaseResponse> GetAssertionResp(GetAssertionFinishRequest responseData, HttpClient _httpClient)
        {
            var baseResp = new BaseResponse();
            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("appsettings.json"))
                {
                    var credentials = await FidoClientServiceCollectionExtensions.LoadServerCredentialsAsync();
                    if (credentials != null)
                    {
                        _httpClient.BaseAddress = new Uri(credentials.BaseURL);
                        _httpClient.DefaultRequestHeaders.Add("X-AMS-API-Key", credentials.ApiKey);
                    }
                }
                var response = await _httpClient.PostAsJsonAsync("/api/fidogetassertionresponse", responseData);
                response.EnsureSuccessStatusCode();
                baseResp = await response.Content.ReadFromJsonAsync<BaseResponse>();
                return baseResp;
            }
            catch (Exception ex)
            {
                baseResp.Status = false;
                baseResp.Message = ex.Message;
                return baseResp;
            }
        }
    }
}
