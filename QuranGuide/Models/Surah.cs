namespace QuranGuide.Models
{
    public class Surah
    {
        public int id {  get; set; }

        public string name { get; set; }

        public int verses_count { get; set; }
        

        public int? revelation_type { get; set; }

        public int? chapter_number { get; set; }

        public ICollection<Verse> verses { get; set; }
    }
}
