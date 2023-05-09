using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using QuranGuide.ViewModels;
using QuranGuide.Models;

namespace QuranGuide.Controllers
{
    public class SearchController : Controller
    {
        private readonly IHttpClientFactory _client;

        public SearchController(IHttpClientFactory client) => _client = client;
       
        public IActionResult search_verse()
        {
            return View();
        }


        public async Task<IActionResult> searched_arabic_verses(string arabic_keyword)
        {
            string URI = "http://api.alquran.cloud/v1/search/" + arabic_keyword + "/all/en";

            //var http_request_message = new HttpRequestMessage(HttpMethod.Get, URL);

            var client = _client.CreateClient();
            var http_response = await client.GetAsync(URI);

            string jsonString = "";


            if (http_response.IsSuccessStatusCode)
            {
                jsonString = await http_response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JsonReceived>(jsonString);
                return View(data);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
