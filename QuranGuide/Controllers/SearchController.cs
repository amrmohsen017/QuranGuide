using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using QuranGuide.Models;
using QuranGuide.Data;

namespace QuranGuide.Controllers
{
    public class SearchController : Controller
    {
        private readonly IHttpClientFactory _client;
        private  QuranContext _db;

        public SearchController(IHttpClientFactory client, QuranContext db)
        {
            _db = db;
            _client = client;
        }
       
        public IActionResult search_verse()
        {
            return View();
        }


        public async Task<IActionResult> searched_arabic_verses(string arabic_keyword)
        {
            try
            {
                //ReadData.fill_database(_db);
                
                return View();


            }
            catch
            {
                return NotFound();
            }
            


        }
    }
}
