using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FidoClientSdk.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("status")]
        [BsonElement("status")]
        public bool Status { get; set; }
        [JsonPropertyName("message")]
        [BsonElement("message")]
        public string Message { get; set; }
    }
}
