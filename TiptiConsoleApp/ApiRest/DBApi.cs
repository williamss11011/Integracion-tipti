using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace TiptiConsoleApp.ApiRest
{
    class DBApi
    {
        public dynamic PostProduct(string url, string json, string key, string autorizacion = null)
        {
           // try
            //{
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            // request.AddHeader("api_key", "x4/oW55H/nr+o+gB/sNPwr0QzZAmzcpa");
            request.AddHeader("Authorization", key);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            if (autorizacion != null)
            {
                request.AddHeader("Authorization", autorizacion);
            }

            IRestResponse response = client.Execute(request);
            dynamic dat = response.IsSuccessful;
            dynamic dat2 = response.StatusDescription;



            if (dat == true || dat2 == "OK")
            {

                dynamic datos = JsonConvert.DeserializeObject(response.Content);
                return datos;
            }
            else
            {
                dynamic datos = "revisar conexion o json";
                return datos;
            }




           /*    }
               catch (Exception ex)
               {
                   Console.WriteLine("Error desde POST:" + ex);
                   return null;
               }*/
        }


        


    }
}
