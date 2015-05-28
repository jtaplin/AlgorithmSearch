using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;

namespace AlgorithmSearch
{
    class Program
    {
        
        public static string FACEBOOK = @"https://www.facebook.com/";
        public static string SEARCH = @"search/str/";
        public static string USER = @"";
        public static string KEYWORD = @"/keywords_users";
        public static string COOKIES = "datr=gJRfVaW3bV036tBXfS-DDZn0; " +
                                "c_user=100009860881350; " +
                                "xs=231%3A1E0AtqNmH595MA%3A2%3A1432327519%3A-1;";
       /* public static string path = @"C:\Users\Baxter\Documents\html\outputs.txt";*/
        public static string path = @"C:\Users\Jake Taplin\Documents\html\outputs.txt";
        public static string name = "";
        static void Main(string[] args)
        {
            Random r = new Random();
            int rInt = r.Next(0, 3); //for ints
            string html = "";
            switch (rInt)
            {
                case 1:
                    USER = "rick";
                    Console.WriteLine("Rick");
                    System.Threading.Thread.Sleep(5000);
                    break;
                case 2:
                    USER = "james";
                    Console.WriteLine("James");
                    System.Threading.Thread.Sleep(5000);
                    break;
                case 3:
                    USER = "sarah";
                    Console.WriteLine("Sarah");
                    System.Threading.Thread.Sleep(5000);
                    break;
            }


            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("user-agent", @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.65 Safari/537.36");
                client.Headers.Add(HttpRequestHeader.Cookie, COOKIES);
                try
                {
                    html = client.DownloadString(FACEBOOK + SEARCH + USER + KEYWORD);
                }
                catch { Console.WriteLine("Error: fetching"); }
            }

            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(html);
            }
            {
                int indexOfPost = html.IndexOf(@"_5d-5");
                string trimmedContent = html.Substring(indexOfPost);
                trimmedContent = html.Substring(0, trimmedContent.IndexOf(@"<div class="));
                int endOfPost = trimmedContent.IndexOf(@"</div>");
                try { name = trimmedContent.Substring(0, endOfPost); }
                catch
                {
                    Console.WriteLine("Error : Trimming HTML");
                    System.Threading.Thread.Sleep(5000);
                }
                Console.WriteLine(name);
            }
        }
    }
}
