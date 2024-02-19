using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookProgram
{
    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authors")]
        public string[] Author { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\n" +
                $"Authors: {String.Join(", ", Author)}\n" +
                $"Description: {Description}\n";
        }
    }
}
