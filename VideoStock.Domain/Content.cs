using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VideoStock.Domain.Enums;

namespace VideoStock.Domain
{
    public class Content
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("addedOn")]
        public DateTime AddedOn { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("type")]
        public ContentType Type { get; set; }
    }
}
