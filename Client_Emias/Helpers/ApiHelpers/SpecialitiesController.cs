using Client_Emias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Helpers.ApiHelpers
{
    public static class SpecialitiesHelper
    {
        private static string Url = $"http://localhost:{App.Port}/Api/Specialities";

        public static string GetSpecialities()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetSpecialityById(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string PutSpeciality(string json, int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PutAsync(Url + "/" + id, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string DeleteSpeciality(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.DeleteAsync(Url + "/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public static string PostSpeciality(string json)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
