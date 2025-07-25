using Microsoft.Extensions.DependencyInjection;
using FidoClientSdk.Clients;
using FidoClientSdk.Interfaces;
using FidoClientSdk.Models;
using System.Text.Json;

namespace FidoClientSdk.Extensions
{
    public static class FidoClientServiceCollectionExtensions
    {
        public static async Task<ServerCredentialsDto?> LoadServerCredentialsAsync()
        {
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            if (!File.Exists(configPath))
                return null;

            var json = await File.ReadAllTextAsync(configPath);
            using var doc = JsonDocument.Parse(json);

            if (!doc.RootElement.TryGetProperty("ServerCredentials", out var creds))
                return null;

            return new ServerCredentialsDto
            {
                BaseURL = AesEncryption.Decrypt(creds.GetProperty("baseuRL").GetString() ?? string.Empty),
                ApiKey = AesEncryption.Decrypt(creds.GetProperty("apiKey").GetString() ?? string.Empty)
            };
        }

    }
}
