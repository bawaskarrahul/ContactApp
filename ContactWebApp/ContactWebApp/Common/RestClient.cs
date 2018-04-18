using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace ContactWebApp.Common
{
    public class RestClient
    {

        private string GetJason(string webmethod, string token)
        {
            try
            {
                WebRequest request = WebRequest.Create(string.Format("{0}{1}", this.baseurl, webmethod));
                request.Headers.Add("TokenHeader", token);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);            // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                return responseFromServer;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        public DataSet GetData(string webmethod, string token)
        {
            try
            {
                string jsonstring = GetJason(webmethod, token);
                var result = new DataSet();
                if (jsonstring.Length > 0)
                {
                    var xd = new XmlDocument();
                    if (jsonstring.Substring(0, 1) == "[")
                    {
                        jsonstring = @"{ tbl: " + jsonstring.Trim().TrimStart('{').TrimEnd('}') + "}";
                    }
                    else
                    {
                        jsonstring = @"{ tbl: [{" + jsonstring.Trim().TrimStart('{').TrimEnd('}') + "}]}";
                    }
                    xd = JsonConvert.DeserializeXmlNode(jsonstring, "tbl");
                    result.ReadXml(new XmlNodeReader(xd));
                }
                return result;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
        public string GetString(string webmethod)
        {
            try
            {
                string jsonstring = GetJason(webmethod, "");
                var str = JsonConvert.DeserializeObject(jsonstring);
                return str.ToString();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        public string PostData(string webmethod,object obj,string Token)
        {
            try
            {
                StreamWriter requestWriter;
                string responseString = "";
                var webRequest = System.Net.WebRequest.Create(string.Format("{0}{1}", this.baseurl, webmethod)) as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("TokenHeader", Token);
                    //POST the data.
                    var json = JsonConvert.SerializeObject(obj);
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(json);
                    }
                    var response = (HttpWebResponse)webRequest.GetResponse();
                    responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
                return responseString;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        private string baseurl
        {
            get { return ConfigurationSettings.AppSettings["BaseURL"].ToString();}
        }

        public string GetAuthToken()
        {
            try
            {
                RestClient _restClient = new RestClient();
                return _restClient.GetString("GetAuthToken");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}