using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Collections;
using System.Linq;

namespace AppPontChaban.Models
{
    public class ApiPontChaban
    {

        public static List<FormatApi> GetListe()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://api.alexandredubois.com/pont-chaban/api.php");
                var stringResult = response.Result.Content.ReadAsStringAsync();
                
                var result = JsonConvert.DeserializeObject<List<FormatApi>>(stringResult.Result);
                return result;

            }

        }
        public static List<FormatApi> FermeturesAVeunir() 
        {
            List<FormatApi> liste = new List<FormatApi>();
           
            foreach (var itmeList in GetListe())
            {
                int result = DateTime.Compare(itmeList.ClosingDate, DateTime.Now);
                //liste.Add(itmeList);

                if (result == 1)
                {
                    var heurs = itmeList.ClosingDate.Hour;
                    if (heurs >= 7 && heurs <= 9 || heurs >= 17 && heurs <= 19)
                    {
                        itmeList.Risquedebouchons = "Elevé";
                    }else
                    {
                        itmeList.Risquedebouchons = "Faible";
                    }
                    
                    liste.Add(itmeList);
                }
            }
            List<FormatApi> SortedList = liste.OrderBy(o => o.ClosingDate).ToList();
            return SortedList;
        }
        public static List<FormatApi> FermeturesPasser() {
            List<FormatApi> liste = new List<FormatApi>();
            foreach (var itmeList in GetListe())
            {
                int result = DateTime.Compare(itmeList.ClosingDate, DateTime.Now);
                //liste.Add(itmeList);

                if (result == -1)
                {
                    liste.Add(itmeList);
                }
            }
            List<FormatApi> SortedList = liste.OrderBy(o => o.ClosingDate).ToList();
            return SortedList;
        }
        public static ArrayList FermeturesPasserANDAVeunir()
        {
            ArrayList tableau = new ArrayList();
            tableau.Add(FermeturesAVeunir());
            tableau.Add(FermeturesPasser());
            return tableau;
        }
        public static List<FormatApi> FermeturesAVeunirSelectNumbr(int numb)
        {
            List<FormatApi> liste = new List<FormatApi>();
            List<FormatApi> elem = FermeturesAVeunir();
            for (int i = 0; i < numb; i++)
            {
                liste.Add(elem[i]);
            }
            return liste;
        }
    }
}
