using Client_Emias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Helpers.ApiHelpers
{
    public static class AppointmentDocumentsHelper
    {
        private static string Url = $"http://localhost:{App.Port}/Api/AppointmentDocuments";

        public static string GetAppointmentDocuments()
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

        public static string GetAppointmentDocumentsId(int id)
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

        public static string PutAppointmentDocuments(string json, int id)
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

        public static string DeleteAppointmentDocuments(int id)
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

        public static string PostAppointmentDocuments(string json)
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

        public static string GetAppointmentsDocumentsByAppointment(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/byappointment/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
