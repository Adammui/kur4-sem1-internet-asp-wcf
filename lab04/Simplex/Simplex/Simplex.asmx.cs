using System;
using System.IO;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web;

namespace Simplex
{
    /// <summary>
    /// Summary description for Simplex
    /// </summary>
    [WebService(Namespace = "http://ADA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class Simplex : WebService
    {

        [WebMethod(Description = "Return sum of x and y", MessageName = "Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "Return concat string and d", MessageName = "Concat")]
        public string Concat(string s, double d)
        {
            return String.Concat(s, d);
        }

        [WebMethod(Description = "Return sum of two objects A", MessageName = "Sum")]
        public A Sum(A a1, A a2)
        {
            string path2 = @"E:\tools\4u1hij\internet\h\lab04\log.txt";

            string text = this.ParseBody(Context.Request); // строка для записи
            File.WriteAllText(path2, text);
            Debug.WriteLine(this.ParseBody(Context.Request));
  
            return new A(
                String.Concat(a1.s + a2.s),
                a1.k + a2.k,
                a1.f + a2.f);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return sum of x and y. Response JSON", MessageName = "Adds")]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
    public static class WebServiceExtensions
    {
        public static string ParseBody(this WebService webService, HttpRequest request)
        {
            request.InputStream.Position = 0;
            var body = string.Empty;

            using (Stream receiveStream = request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, true))
                {
                    body = readStream.ReadToEnd();
                }
            }

            return body;
        }
    }
}
