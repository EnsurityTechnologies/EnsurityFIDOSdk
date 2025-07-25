using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class GetAssertionRequest
    {
        [JsonPropertyName("username")]
        [BsonElement("username")]
        public string Username { get; set; }
    }
}
