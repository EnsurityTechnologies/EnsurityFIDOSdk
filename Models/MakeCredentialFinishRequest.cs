using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class MakeCredentialFinishRequest
    {
        [JsonPropertyName("username")]
        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("session_id")]
        [BsonElement("session_id")]
        public string SessionId { get; set; } = string.Empty;

        [JsonPropertyName("credential_creation_response")]
        [BsonElement("credential_creation_response")]
        public CredentialCreationResponse CredentialCreationResponse { get; set; } = new();
    }

    public class CredentialCreationResponse
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
        public CredentialResponse Response { get; set; } = new();
    }
    public class CredentialResponse
    {
        [JsonPropertyName("clientDataJSON")]
        [BsonElement("clientDataJSON")]
        public string ClientDataJSON { get; set; } = string.Empty;

        [JsonPropertyName("attestationObject")]
        [BsonElement("attestationObject")]
        public string AttestationObject { get; set; } = string.Empty;
    }

}
