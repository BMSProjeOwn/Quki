using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Integrations
{
    public class Conncetion
    {
        public string PostConnectionHeaderList(string URL, string Request, List<HeaderClass> headerList, bool PreAuthenticate)
        {

            string response = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Timeout = 30000;
            request.Method = "POST";
            request.ContentType = "application/json";
            if (headerList != null)
            {
                for (int i = 0; i < headerList.Count; i++)
                {
                    request.Headers.Add(headerList[i].Name, headerList[i].Value);
                }
            }
            request.ContentLength = Request.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream))
            {
                requestWriter.Write(Request);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream, false))
                {
                    response = responseReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
            }

            return response;
        }


        public string SendMail(string url, string Request, List<HeaderClass> headerList)
        {
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(Request);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            if (headerList != null)
            {
                for (int i = 0; i < headerList.Count; i++)
                {
                    request.Headers.Add(headerList[i].Name, headerList[i].Value);
                }
            }

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }


        public string PATCHConnectionHeaderList(string URL, string Request, List<HeaderClass> headerList, bool PreAuthenticate)
        {
            string response = "";
            try
            {
                WebRequest request = WebRequest.Create(URL);
                request.Method = "PATCH";
                request.ContentType = "application/json";
                request.Timeout = 30000;
                if (headerList != null)
                {
                    for (int i = 0; i < headerList.Count; i++)
                    {
                        request.Headers.Add(headerList[i].Name, headerList[i].Value);
                    }
                }

                if (PreAuthenticate)
                    request.PreAuthenticate = true;

                request.ContentLength = Request.Length;
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream))
                {
                    requestWriter.Write(Request);
                }

                try
                {
                    WebResponse webResponse = request.GetResponse();
                    using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                    using (StreamReader responseReader = new StreamReader(webStream, false))
                    {
                        response = responseReader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                }
            }
            catch (Exception ex) { }
            return response;
        }

        public string GetConnectionHeaderList(string URL, List<HeaderClass> headerList, bool PreAuthenticate)
        {
            string rt = "";
            WebRequest request = WebRequest.Create(URL);
            request.Timeout = 30000;
            if (headerList != null)
            {
                for (int i = 0; i < headerList.Count; i++)
                {
                    request.Headers.Add(headerList[i].Name, headerList[i].Value);
                }
            }

            if (PreAuthenticate)
                request.PreAuthenticate = true;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return rt;
        }

        public string PutConnectionHeaderList(string URL, string Request, List<HeaderClass> headerList, bool PreAuthenticate)
        {
            string response = "";
            WebRequest request = WebRequest.Create(URL);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Timeout = 30000;
            if (headerList != null)
            {
                for (int i = 0; i < headerList.Count; i++)
                {
                    request.Headers.Add(headerList[i].Name, headerList[i].Value);
                }
            }

            if (PreAuthenticate)
                request.PreAuthenticate = true;

            request.ContentLength = Request.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream))
            {
                requestWriter.Write(Request);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream, false))
                {
                    response = responseReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
            }
            return response;
        }

        public string DelConnectionHeaderList(string URL, List<HeaderClass> headerList, bool PreAuthenticate)
        {
            string rt = "";
            WebRequest request = WebRequest.Create(URL);
            request.Method = "DELETE";
            request.Timeout = 30000;
            if (headerList != null)
            {
                for (int i = 0; i < headerList.Count; i++)
                {
                    request.Headers.Add(headerList[i].Name, headerList[i].Value);
                }
            }

            if (PreAuthenticate)
                request.PreAuthenticate = true;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return rt;
        }
    }

    public class HeaderClass
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
