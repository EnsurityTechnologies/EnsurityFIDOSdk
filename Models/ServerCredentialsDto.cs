using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class ServerCredentialsDto
    {
        [JsonPropertyName("baseuRL")]
        [BsonElement("baseuRL")]
        public string BaseURL { get; set; } = string.Empty;
        [JsonPropertyName("apiKey")]
        [BsonElement("apiKey")]
        public string ApiKey { get; set; } = string.Empty;
    }
}
