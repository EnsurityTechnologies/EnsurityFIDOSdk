using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class MakeCredentialResponse: BaseResponse
    {
        [JsonPropertyName("session_id")]
        [BsonElement("session_id")]
        public string SessionId { get; set; } = string.Empty;

        [JsonPropertyName("credential_creation")]
        [BsonElement("credential_creation")]
        public CredentialCreation CredentialCreation { get; set; } = new();
    }

    public class CredentialCreation
    {
        [JsonPropertyName("publicKey")]
        [BsonElement("publicKey")]
        public PublicKeyOptions PublicKey { get; set; } = new();
    }
    public class PublicKeyOptions
    {
        [JsonPropertyName("authenticatorSelection")]
        [BsonElement("authenticatorSelection")]
        public AuthenticatorSelection AuthenticatorSelection { get; set; } = new();

        [JsonPropertyName("challenge")]
        [BsonElement("challenge")]
        public string Challenge { get; set; } = string.Empty;

        [JsonPropertyName("pubKeyCredParams")]
        [BsonElement("pubKeyCredParams")]
        public List<PubKeyCredParam> PubKeyCredParams { get; set; } = new();

        [JsonPropertyName("rp")]
        [BsonElement("rp")]
        public RelyingParty Rp { get; set; } = new();

        [JsonPropertyName("timeout")]
        [BsonElement("timeout")]
        public int Timeout { get; set; }

        [JsonPropertyName("user")]
        [BsonElement("user")]
        public PublicKeyUser User { get; set; } = new();
    }

    public class AuthenticatorSelection
    {
        [JsonPropertyName("requireResidentKey")]
        [BsonElement("requireResidentKey")]
        public bool RequireResidentKey { get; set; }

        [JsonPropertyName("residentKey")]
        [BsonElement("residentKey")]
        public string ResidentKey { get; set; } = string.Empty;
    }

    public class PubKeyCredParam
    {
        [JsonPropertyName("type")]
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("alg")]
        [BsonElement("alg")]
        public int Alg { get; set; }
    }

    public class RelyingParty
    {
        [JsonPropertyName("name")]
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        [BsonElement("id")]
        public string Id { get; set; } = string.Empty;
    }

    public class PublicKeyUser
    {
        [JsonPropertyName("name")]
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("displayName")]
        [BsonElement("displayName")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        [BsonElement("id")]
        public string Id { get; set; } = string.Empty;
    }
}
