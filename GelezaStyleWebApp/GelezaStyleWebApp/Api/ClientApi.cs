using GelezaStyleService.Models;
using GelezaStyleWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GelezaStyleWebApp.Api
{
    public class ClientApi
    {
        private HttpClient httpClient = new HttpClient();

        public ClientApi()
        {
            
           //httpClient.BaseAddress = new Uri("http://192.168.192.1:8090/");
            httpClient.BaseAddress = new Uri("http://localhost:35985/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
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


        public async Task<Client> GetClient(int Id)
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Client/GetClient/{Id}");

            Client client = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                client = JsonConvert.DeserializeObject<Client>(json);
            }

            return client;

        }


        public async Task<IEnumerable<Client>> GetAllClients()
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Client/GetAllClients");

            IEnumerable<Client> clients = null;

            if(http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(json);
            }

            return clients;
        }

        public async Task<int> UpdateClient(Client client)
        {
            string json = JsonConvert.SerializeObject(client);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PutAsync($"/api/Client/UpdateClient", httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }

        public async Task<int> ActivateClient(string email, int chActive)
        {
            Client client = new Client()
            {
                ClientEmail = email,
                ClientIsActive = chActive
            };

            string json = JsonConvert.SerializeObject(client);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PutAsync($"/api/Client/ActivateClient/{email}/{chActive}", httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }



        /************************************SCHOOOLS ONLY****************/
        public async Task<int> CreateSchool(Schools school)
        {
            string json = JsonConvert.SerializeObject(school);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PostAsync($"/api/School/CreateSchool", httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }

        public async Task <IEnumerable<Schools>> GetSchools()
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/School/GetSchools");

            IEnumerable<Schools> schools = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                schools = JsonConvert.DeserializeObject<IEnumerable<Schools>>(json);
            }

            return schools;

        }

        public async Task<Schools> GetSchool(int Id)
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/School/GetSchool/{Id}");

            Schools school = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                school = JsonConvert.DeserializeObject<Schools>(json);
            }

            return school;

        }

        public async Task<int> DeleteSchool(int Id)
        {
            string json = JsonConvert.SerializeObject(Id);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";

            HttpResponseMessage httpResponse = await httpClient.PutAsync($"/api/School/DeleteSchool/{Id}",httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }



        public async Task<int> UpdateSchool(Schools schools)
        {
            string json = JsonConvert.SerializeObject(schools);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PutAsync($"/api/School/updateSchool", httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }

        public async Task<IEnumerable<Schools>> GetActiveSchools(int intActive)
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/School/GetActiveSchools/{intActive}");

            IEnumerable<Schools> schools = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                schools = JsonConvert.DeserializeObject<IEnumerable<Schools>>(json);
            }

            return schools;
        }


        /*******************************************ITEMS ONLY***********************************************/
        public async Task<int> CreateItem(Items school)
        {
            string json = JsonConvert.SerializeObject(school);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            string strResponse = "";


            HttpResponseMessage httpResponse = await httpClient.PostAsync($"/api/Item/CreateItem", httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                strResponse = await httpResponse.Content.ReadAsStringAsync();
            }


            int intResponse;
            int.TryParse(strResponse, out intResponse);

            return intResponse;
        }


        public async Task<IEnumerable<Items>> GetAllItems()
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Item/GetAllItems");

            IEnumerable<Items> items = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                items = JsonConvert.DeserializeObject<IEnumerable<Items>>(json);
            }

            return items;
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


        public async Task<IEnumerable<Items>> GetByGender(string gender)
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Item/GetByGender/{gender}");

            IEnumerable<Items> itemsByGender = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                itemsByGender = JsonConvert.DeserializeObject<IEnumerable<Items>>(json);
            }

            return itemsByGender;

        }




        /****************************************COMPATIBILITIES************************************/

        public async Task<int> CreateCompatibility(Compatibility comp)
        {
            string uri = $"api/Compatibility/CreateCompatibility";
            string json = JsonConvert.SerializeObject(comp);
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

        public async Task<IEnumerable<Compatibility>> GetCompatibility(int itemID)
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Compatibility/GetCompatibility/{itemID}");

            IEnumerable<Compatibility> compatibility = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                compatibility = JsonConvert.DeserializeObject<IEnumerable<Compatibility>>(json);
            }

            return compatibility;

        }

        /***********************************ORDERS****************************************************/
        public async Task<IEnumerable<Orders>> GetNewOrders()
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Orders/GetNewOrders");

            IEnumerable<Orders> orders = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                orders = JsonConvert.DeserializeObject<IEnumerable<Orders>>(json);
            }

            return orders;
        }

        public async Task<IEnumerable<Orders>> GeAllOrders()
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Orders/GetAllOrders");

            IEnumerable<Orders> orders = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                orders = JsonConvert.DeserializeObject<IEnumerable<Orders>>(json);
            }

            return orders;
        }



        public async Task<IEnumerable<Orders>> GetCompletedOrders()
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Orders/GetCompletedOrders");

            IEnumerable<Orders> orders = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                orders = JsonConvert.DeserializeObject<IEnumerable<Orders>>(json);
            }

            return orders;
        }


        public async Task<int> CompleteOrder(int OrderId)
        {

            string json = JsonConvert.SerializeObject(OrderId);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage http = await httpClient.PutAsync($"/api/Orders/CompleteOrder/{OrderId}",httpContent);

            
            string response = "";

            if (http.IsSuccessStatusCode)
            {
                response = await http.Content.ReadAsStringAsync();
            }

            return Convert.ToInt32(response);
        }




        /***********************************************************VIEW ORDERS***************************************************/

        public async Task<IEnumerable<ViewOrders>> viewOrders(int orderID)
        {
            HttpResponseMessage http = await httpClient.GetAsync($"/api/Orders/ViewOrderedItems/{orderID}");

            IEnumerable<ViewOrders> viewOrders = null;

            if (http.IsSuccessStatusCode && http != null)
            {
                string json = await http.Content.ReadAsStringAsync();

                viewOrders = JsonConvert.DeserializeObject<IEnumerable<ViewOrders>>(json);
            }

            return viewOrders;
        }


    }
}