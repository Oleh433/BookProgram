using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookProgram
{
    public class Book
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public VolumeInfo VolumeInfo { get; set; }

        public override string ToString()
        {
            return $"Book id: {Id}\n{VolumeInfo.ToString()}";
        }
    }
}
