using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Windows.Forms;

using DesktopApplication.Models;
using System.Threading.Tasks;

namespace DesktopApplication
{
    //Defined as a Singleton
    public class APIConnection
    {
        //Singleton
        private static APIConnection m_instance;

        public static APIConnection Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new APIConnection();
                }
                return m_instance;
            }
        }

        //APIConnection
        private HttpClient m_client;
        private User m_account;

        private APIConnection()
        {
            m_account = new User();

            m_client = new HttpClient();
            m_client.BaseAddress = new Uri("http://localhost:55254/api/");
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/JSON"));
        }

        public User Auth
        {
            get
            {
                return m_account;
            }
            set
            {
                m_account = value;
            }
        }


        public async Task<Type> Get<Type>(string path)
        {
            HttpResponseMessage response = m_client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Type>();
            }
            return default(Type);
        }

        public async Task<bool> Post<Type>(Type item, string path)
        {
            HttpResponseMessage response = await m_client.PostAsJsonAsync(path, item);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Put<Type>(Type item, string path)
        {
            HttpResponseMessage response = await m_client.PutAsJsonAsync(path, item);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(string path)
        {
            HttpResponseMessage response = await m_client.DeleteAsync(path);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
