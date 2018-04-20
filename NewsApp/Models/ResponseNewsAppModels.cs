using NewsAPI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace NewsApp.Models
{
    public class ResponseNewsAppModels
    {

        public string TransportJsonNewsWithApp(string category)
        {
            var url = "";
            if (category != "top")
                url = "https://newsapi.org/v2/top-headlines?" + "country=pl&category=" + category + "&apiKey=6c97f7dda29e468fa1bcc022a7efae70";
            else 
                url = "https://newsapi.org/v2/top-headlines?" + "country=pl" + "&apiKey=6c97f7dda29e468fa1bcc022a7efae70";

            string json;
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                json = webClient.DownloadString(url);
            }
            
            JObject jsonObject = JObject.Parse(json);
            return jsonObject["articles"].ToString();
        }


    }
}