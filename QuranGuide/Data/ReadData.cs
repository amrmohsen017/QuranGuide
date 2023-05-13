using Microsoft.EntityFrameworkCore;
using QuranGuide.Models;
using System.Text.RegularExpressions;

namespace QuranGuide.Data
{
    public static class ReadData
    {
        

        public static void fill_database_if_empty(IApplicationBuilder applicationBuilder)
        {
            QuranContext db = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<QuranContext>();

            
            if(db.surahs.ToList().Count == 0)
            {

                //reading txt file into large string
                string text = File.ReadAllText("C:\\Users\\Amr Mohsen\\Downloads\\quran.txt");

                //spliting the large string into surahs
                string[] text_array = text.Split("سورة");

                //removing newlines from all strings.
                string[] charsToRemove = { "\n" };
                for (var i = 1; i < 115; i++)
                {
                    foreach (var c in charsToRemove)
                    {
                        text_array[i] = text_array[i].Replace(c, string.Empty);
                    }
                }



                //char array for splitting every surah on.
                char[] verse_char_splits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(', ')', '\r' };
                List<string> verses_list = null;
                

                //looping on all the surahs
                for (var surah_iterator = 2; surah_iterator <= 114; surah_iterator++)
                {

                    //splitting surah into verses
                    string[] verses_array = text_array[surah_iterator].Split(verse_char_splits);

                    //converting array to list to remove extensions.
                    verses_list = verses_array.ToList();
                    verses_list.RemoveAll(x => x == "");

                    //getting verses list count for the loop.
                    int verse_list_size = verses_list.Count;


                    Surah s = new Surah()
                    {
                        name = verses_list[0],
                        id = surah_iterator,
                        verses_count = verse_list_size - 2
                    };
                    

                    if (surah_iterator == 9)
                    {
                        s.verses_count = verse_list_size - 1;
                        verse_list_size++;
                    }

                    db.surahs.Add(s);
                    db.SaveChanges();

                    //looping on surah's verses.
                    for (var verse_iterator=2; verse_iterator < verse_list_size; verse_iterator++)
                    {
                        //System.Diagnostics.Debug.WriteLine(surah_iterator);
                        //System.Diagnostics.Debug.WriteLine(verse_iterator);

                        //if condition for tawba surah.
                        if(surah_iterator == 9)
                        {
                            db.verses.Add(new Verse
                            {
                                id = verse_iterator - 1,
                                surahId = surah_iterator,
                                text = verses_list[verse_iterator-1]
                            });
                        }
                        else
                        {
                            db.verses.Add(new Verse
                            {
                                id = verse_iterator - 1,
                                surahId = surah_iterator,
                                text = verses_list[verse_iterator]
                            });
                        }
                       

                    }


                    db.SaveChanges();


                }

                //this below code for alfattah surah only (same as the code above)
                string[] fattah_verses = text_array[1].Split(verse_char_splits);
                List<string> fattah_verses_l = fattah_verses.ToList();
                fattah_verses_l.RemoveAll(x => x == "");

                Surah f_s = new Surah()
                {
                    name = fattah_verses_l[0],
                    id = 1,
                    verses_count = 7
                };
                db.surahs.Add(f_s);
                db.SaveChanges();

                for(int j=1;j< fattah_verses_l.Count;j++)
                {
                    db.verses.Add(new Verse
                    {
                        id = j,
                        surahId = 1,
                        text = fattah_verses_l[j]

                    });

                }

                db.SaveChanges();
                
            }
            

            
        }
    }
}
