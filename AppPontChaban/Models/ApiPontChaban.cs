using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Collections;

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
                    liste.Add(itmeList);
                }
            }
            return liste;
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
            return liste;
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
