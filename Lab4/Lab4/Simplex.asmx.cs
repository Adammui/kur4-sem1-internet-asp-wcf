using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text;

namespace Lab4
{
    [WebService(Namespace = "http://rpa/", Description = "WebServices lab #4")]
    [ScriptService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Simplex : System.Web.Services.WebService
    {
        [WebMethod(MessageName = "Sum_1", Description = "Return sum of two ints")]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [WebMethod(MessageName = "Sum_2", Description = "Return concat of string and double")]
        public string Concat(string s, double d)
        {
            return s + d.ToString();
        }
        [WebMethod(MessageName = "Sum_3", Description = "Return new object from two provided")]
        public A Sum(A a1, A a2)
        {

            string path2 = @"E:\asp\Lab4\Lab4\log2.txt";
    
            string text = this.ParseBody(Context.Request); // строка для записи
            File.WriteAllText(path2, text);
            Debug.WriteLine(this.ParseBody(Context.Request));
            return new A
            {
                s = a1.s + a2.s,
                k = a1.k + a2.k,
                f = a1.f + a2.f
            };
        }

        //////////////////////
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "Sum_4", Description = "Sum of 2 int. Response JSON")]

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
