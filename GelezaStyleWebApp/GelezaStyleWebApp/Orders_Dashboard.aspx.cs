using FusionCharts.Charts;
using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class Orders_Dashboard : System.Web.UI.Page
    {
        private ClientApi api = new ClientApi();

        protected void Page_Load(object sender, EventArgs e)
        {
            drawStatusesChart();
        }

        private async void drawStatusesChart()
        {

            IEnumerable<Orders> IAllOrders = await api.GeAllOrders();

            List<Orders> allOrders = new List<Orders>(IAllOrders);

            double Complete = 0;

            double NotComplete = 0;

          


            foreach (var c in allOrders)
            {
                if (c.OrderIsReady == 1)
                {
                    Complete++;
                }
                else if (c.OrderIsReady == 0)
                {
                   NotComplete++;
                }
         
            }

            string jsonData = "{'chart':{'caption': 'Pie chart displaying Order Completion for orders in October', 'enableMultiSlicing':'1', 'theme': 'fusion'}, 'data': [{'label': 'Completed', 'value': '" + Complete + "'}, {'label': 'Not Completed','value': '" + NotComplete + "'}]}";
            // create chart instance
            Chart chart = new Chart();
           
            // parameter
            // chrat type, chart id, chart widh, chart height, data format, data source
            Chart pie3D = new Chart("pie3d", "CompC", "600", "400", "json", jsonData);
            //render chart
            chartContainer.Text = pie3D.Render();
        }
    }
}