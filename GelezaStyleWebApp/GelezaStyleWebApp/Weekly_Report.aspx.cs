using System;
using System.Collections.Generic;
using System.Linq;
using FusionCharts.Charts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;

namespace GelezaStyleWebApp
{
    public partial class Weekly_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            drawWeeklyChart();
        }

        private void drawWeeklyChart()
        {
            try
            {

                //store label-value pair
                // gettingTheStuff stuff = new gettingTheStuff();
                // stuff.getTripsDone();
                // List<KeyValuePair<string, int>> dataValuePair = await getComplaints();
                List<KeyValuePair<string, int>> dataValuePair = new List<KeyValuePair<string, int>>();

                int numDress = 42;
                int numShirt = 56;
                int numSkirt = 38;
                int numTrouser = 25;
                int numTie = 20;
                int numJersey = 15;
                int numSocks = 46;
             
                dataValuePair.Add(new KeyValuePair<string, int>("Dresses", numDress));
                dataValuePair.Add(new KeyValuePair<string, int>("Shirts", numShirt));
                dataValuePair.Add(new KeyValuePair<string, int>("Trousers", numTrouser));
                // dataValuePair.Add(new KeyValuePair<string, int>("Sink", numS++));
                // dataValuePair.Add(new KeyValuePair<string, int>("Water Closet", numWC++));
                //  dataValuePair.Add(new KeyValuePair<string, int>("Shower", numSh++));
                dataValuePair.Add(new KeyValuePair<string, int>("Ties", numTie));
                // dataValuePair.Add(new KeyValuePair<string, int>("Cardboard", numCB++));
                dataValuePair.Add(new KeyValuePair<string, int>("Skirts", numSkirt));
                dataValuePair.Add(new KeyValuePair<string, int>("Jersey", numJersey));
                dataValuePair.Add(new KeyValuePair<string, int>("Socks", numSocks));
                // dataValuePair.Add(new KeyValuePair<string, int>("Other", num++));

                StringBuilder data = new StringBuilder();
                StringBuilder jsonData = new StringBuilder();

                Dictionary<string, string> chartConfig = new Dictionary<string, string>();
                chartConfig.Add("caption", "Bar graph displaying weekly purchases on category items for October 2022");
                // chartConfig.Add("subCaption", "The Number of Complaints");
                chartConfig.Add("xAxisName", "Clothing Categories");
                chartConfig.Add("yAxisName", "Number of clothing items bought under category");
                chartConfig.Add("numberSuffix", "");
                chartConfig.Add("theme", "fusion");

                jsonData.Append("{'chart':{");
                foreach (var config in chartConfig)
                {
                    jsonData.AppendFormat("'{0}':'{1}',", config.Key, config.Value);
                }
                jsonData.Replace(",", "},", jsonData.Length - 1, 1);

                data.Append("'data':[");
                foreach (KeyValuePair<string, int> pair in dataValuePair)
                {
                    data.AppendFormat("{{'label':'{0}','value':'{1}'}},", pair.Key, pair.Value);
                }
                data.Replace(",", "]", data.Length - 1, 1);





                // json data to use as chart data source



                jsonData.Append(data.ToString());
                jsonData.Append("}");

                //Create chart instance
                // charttype, chartID, width, height, data format, data
                Chart CompChart = new Chart("column2d", "ComplaintssChart", "800", "550", "json", jsonData.ToString());

                // render chart

                CompID.Text = CompChart.Render();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}