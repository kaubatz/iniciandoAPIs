using System;
using System.Net;
using System.IO;
using System.Text;

namespace consumindoWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            var request = (HttpWebRequest) WebRequest.Create("https://localhost:44317/api/webservice/lercliente/123");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta do metodo GET: " + responseString);
            */

            var request = (HttpWebRequest)WebRequest.Create("https://localhost:44317/api/webservice/gravardados");
            //var postData = "var1=val1&var2=val2";
            var postData = " { 'var1'='val1' }";
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta do metodo POST: " + responseString);
        }
    }
}
