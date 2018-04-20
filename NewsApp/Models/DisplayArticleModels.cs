using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApp.Models
{
    public class DisplayArticle
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idArticle { get; set; }

        public string author { get; set; }

        public string source {get; set;}
    
        public string title { get; set; }

       
        public string description { get; set; }


        public string url { get; set; }


        public string urlToImage { get; set; }


        public string publishetAt { get; set; }

        public int idCateogry { get; set; }
    }

   
}