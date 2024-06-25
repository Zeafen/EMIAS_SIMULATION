using Client_Emias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Helpers.ApiHelpers
{
    public static class AppointmentsHelper
    {
        private static string Url = "http://localhost5102/Api/Appointments";

        public static string GetAppointments()
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
        public static string GetActiveAppointments()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/active").Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string GetArchivedAppointments()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/archived").Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string GetAppointmentsByDocID(int docID)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/bydoctor/"+ docID).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetAppointmentsId(int id)
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

        public static string PutAppointments(string json, int id)
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

        public static string DeleteAppointments(int id)
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

        public static string PostAppointment(string json)
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

        public static string GetDoctorsBusyTime(int id, string jsonDate)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(jsonDate, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url + "/busytime/" + id, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetAppointmentByOms(long oms)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/byoms/" + oms).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
