using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class GetAssertionFinishRequest
    {
        [JsonPropertyName("username")]
        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("session_id")]
        [BsonElement("session_id")]
        public string SessionId { get; set; } = string.Empty;

        [JsonPropertyName("credential_assertion_response")]
        [BsonElement("credential_assertion_response")]
        public CredentialAssertionResponse CredentialAssertionResponse { get; set; } = new();
    }

    public class CredentialAssertionResponse
    {
        [JsonPropertyName("authenticatorAttachment")]
        [BsonElement("authenticatorAttachment")]
        public string? AuthenticatorAttachment { get; set; }

        [JsonPropertyName("id")]
        [BsonElement("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("rawId")]
        [BsonElement("rawId")]
        public string RawId { get; set; } = string.Empty;

        [JsonPropertyName("response")]
        [BsonElement("response")]
        public AssertionResponse Response { get; set; } = new();
    }

    public class AssertionResponse
    {
        [JsonPropertyName("authenticatorData")]
        [BsonElement("authenticatorData")]
        public string AuthenticatorData { get; set; } = string.Empty;

        [JsonPropertyName("clientDataJSON")]
        [BsonElement("clientDataJSON")]
        public string ClientDataJSON { get; set; } = string.Empty;

        [JsonPropertyName("signature")]
        [BsonElement("signature")]
        public string Signature { get; set; } = string.Empty;

        [JsonPropertyName("userHandle")]
        [BsonElement("userHandle")]
        public string UserHandle { get; set; } = string.Empty;
    }
}
