using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApp.Models
{
    public class NewArticle
    {
        
        [JsonProperty("source")]
        public NewSource newSource { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int newIdArticle { get; set; }

        [JsonProperty("author")]
        public string newAuthor { get; set; }

        [JsonProperty("title")]
        public string newTitle { get; set; }

        [JsonProperty("description")]
        public string newDescription { get; set; }

        [JsonProperty("url")]
        public string newUrl { get; set; }

        [JsonProperty("urlToImage")]
        public string newUrlToImage { get; set; }

        [JsonProperty("publishetAt")]
        public string newPublishetAt { get; set; }
    }

    public class NewSource
    {
        [JsonProperty("id")]
        public string newId { get; set; }

        [JsonProperty("name")]
        public string newName { get; set; }
    }
}