using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookProgram.Models
{
    public class VolumeInfo
    {
        public string Title { get; set; }

        public string[] Authors { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\n" +
                $"Authors: {string.Join(", ", Authors)}\n" +
                $"Description: {Description}\n";
        }
    }
}
