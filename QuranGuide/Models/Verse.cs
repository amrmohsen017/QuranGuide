using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuranGuide.Models
{
    public class Verse
    {

        public int id { get; set; }

        public int surahId { get; set; }

        public string text { get; set; }

        public  Surah surah { get; set; }
    }
}
