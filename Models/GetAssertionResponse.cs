using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class GetAssertionResponse: BaseResponse
    {
        [JsonPropertyName("session_id")]
        [BsonElement("session_id")]
        public string SessionId { get; set; } = string.Empty;

        [JsonPropertyName("credential_assertion")]
        [BsonElement("credential_assertion")]
        public CredentialAssertions CredentialAssertion { get; set; } = new();
    }

    public class CredentialAssertions
    {
        [JsonPropertyName("publicKey")]
        [BsonElement("publicKey")]
        public PublicKeyRequestOptions PublicKey { get; set; } = new();
    }

    public class PublicKeyRequestOptions
    {
        [JsonPropertyName("challenge")]
        [BsonElement("challenge")]
        public string Challenge { get; set; } = string.Empty;

        [JsonPropertyName("timeout")]
        [BsonElement("timeout")]
        public int Timeout { get; set; }

        [JsonPropertyName("rpId")]
        [BsonElement("rpId")]
        public string RpId { get; set; } = string.Empty;

        [JsonPropertyName("userVerification")]
        [BsonElement("userVerification")]
        public string UserVerification { get; set; } = string.Empty;

        [JsonPropertyName("allowCredentials")]
        [BsonElement("allowCredentials")]
        public List<PublicKeyCredentialDescriptor> AllowCredentials { get; set; } = new();
    }

    public class PublicKeyCredentialDescriptor
    {
        [JsonPropertyName("type")]
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        [BsonElement("id")]
        public string Id { get; set; } = string.Empty;
    }
}
