using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaxoDAL;

namespace SaxoBusinessComp
{
    public class SaxoApiWraper
    {

        public RootObject CallSaxoApi(string isbnNumbers)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var uri = new Uri(ConfigurationManager.AppSettings["SaxoApiUrl"] + "v1/products/products.json?key=" + ConfigurationManager.AppSettings["SaxoApiKey"] + "&isbn=" + isbnNumbers);
                    //var uri = new Uri(ConfigurationManager.AppSettings["SaxoApiUrl"] + "v1/products/products.json?key=" + ConfigurationManager.AppSettings["SaxoApiKey"] + "&query=SELECT * FROM Products WHERE id=21288947");
                    var responsejsonString = client.DownloadString(uri);
                    var productList = JsonConvert.DeserializeObject<RootObject>(responsejsonString);
                    return productList;

                }
                catch (Exception ex)
                {
                    return null;
                }

                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["SaxoApiUrl"] + "v1/products/products.json?key=" + ConfigurationManager.AppSettings["SaxoApiKey"] + "&isbn=" + isbnNumbers);
                //HttpWebResponse response2 = (HttpWebResponse)request.GetResponse();
                //string responseURI = response.ResponseUri;
            }
        }
    }
}
