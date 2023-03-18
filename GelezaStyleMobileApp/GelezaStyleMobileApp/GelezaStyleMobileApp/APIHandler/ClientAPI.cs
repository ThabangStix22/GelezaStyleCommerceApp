using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GelezaStyleMobileApp.Models;
using Newtonsoft.Json;

namespace MobileApp.ApiHandler
{
    class ClientAPI
    {
        private readonly HttpClient httpClient = new HttpClient();


        public ClientAPI()
        {
            httpClient.BaseAddress = new Uri("http://172.24.240.1:8090/");
            //httpClient.BaseAddress = new Uri("http://localhost:5000/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }



        /*******************************CLIENT*********************************/
        public async Task<Client> LoginClient(string email, string password)
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/Client/LoginClient/{email}/{password}");

            Client client = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                client = JsonConvert.DeserializeObject<Client>(json);
            }

            return client;
        }

        public async Task<int> CreateClient(Client client)
        {
            string uri = $"api/Client/CreateClient";
            string json = JsonConvert.SerializeObject(client);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PostAsync(uri, httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }


        public async Task<Client> GetClient(int clientID)
        {
          
            HttpResponseMessage http = await httpClient.GetAsync($"api/Client/GetClient/{clientID}");

            Client client = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                client = JsonConvert.DeserializeObject<Client>(json);
            }

            return client;

        }

        public async Task<int> updateClient(Client client)
        {
            string uri = $"api/Client/UpdateClient";
            string json = JsonConvert.SerializeObject(client);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PutAsync(uri, httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }


        /*******************************SCHOOLS*********************************/

        public async Task<IEnumerable<Schools>> GetActiveSchools(int chActive)
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/School/GetActiveSchools/{chActive}");


            IEnumerable<Schools> schools = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                schools = JsonConvert.DeserializeObject<IEnumerable<Schools>>(json);
            }

            return schools;
        }

        /***********************************ITEMS********************************************************/
        public async Task<Items> GetItem(int ItemID)
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/Item/GetItem/{ItemID}");


            Items item = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                item = JsonConvert.DeserializeObject<Items>(json);
            }

            return item;
        }


        public async Task<List<string>> GetItemsSizeByName(string itemName)
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/Item/GetItemSizesByName/{itemName}");


            List<string> sizes = new List<string>();

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                sizes = JsonConvert.DeserializeObject<List<string>>(json);
            }

            return sizes;
        }

        public async Task<IEnumerable<Items>> GetActiveItems(int chActive)
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/Item/GetActiveItems/{chActive}");


            IEnumerable<Items> items = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                items = JsonConvert.DeserializeObject<IEnumerable<Items>>(json);
            }

            return items;
        }


        public async Task<IEnumerable<Items>> GetActiveItemsBySchoolId(int schoolId)
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/Item/GetItemsBySchool/{schoolId}");


            IEnumerable<Items> items = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                items = JsonConvert.DeserializeObject<IEnumerable<Items>>(json);
            }

            return items;
        }



        


        /***************************************ORDERS*********************************************************************/

        public async Task<int> CreateOrder(Orders order)
        {

            string uri = $"api/Orders/CreateOrder";
            string json = JsonConvert.SerializeObject(order);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PostAsync(uri, httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;


        }


        public async Task<int> GetLastOrderId()
        {

            HttpResponseMessage http = await httpClient.GetAsync($"/api/Orders/GetLastOrderId");


            int LastId = 0;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                LastId = JsonConvert.DeserializeObject<int>(json);
            }

            return LastId;
        }


        /******************************************ORDERED ITEMS****************************************/

        public async Task<int> CreateOrderedItems(List<OrderedItems> orderedItems)
        {
            string uri = $"api/OrderedItems/CreateOrderedItems";
            string json = JsonConvert.SerializeObject(orderedItems);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PostAsync(uri, httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse = Convert.ToInt32(strResponse);
            

            return intResponse;
        }


    }
}
