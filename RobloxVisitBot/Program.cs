using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace RobloxVisitBot
{
    class Program
    {
        static string CSRFToken(string cookie)
        {
            try
            {
                WebClient wb = new WebClient();
                wb.Headers["Cookie"] = ".ROBLOSECURITY=" + cookie;
                Regex regex = new Regex("Roblox.XsrfToken.*?\'(.*)\'");
                Match matched = regex.Match(wb.DownloadString("https://www.roblox.com/groups/4539492/The-Republic-Navy#!/about"));

                if (matched.Success)
                {
                    return matched.Groups[1].Value;
                }
                else
                {
                    return "Failed";
                }


            }
            catch (WebException ex)
            {
                return "Failed";

            }


        }
        static string Grab_Auth_Ticket(long id)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://auth.roblox.com/v1/authentication-ticket/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            httpWebRequest.Headers.Add(HttpRequestHeader.Cookie, string.Format(".ROBLOSECURITY={0}", System.IO.File.ReadAllText("Cookie.txt")));
            httpWebRequest.Headers.Add("X-CSRF-TOKEN", CSRFToken(System.IO.File.ReadAllText("Cookie.txt")));
            httpWebRequest.Referer = "https://www.roblox.com/games/" +id;
            httpWebRequest.ContentLength = 0;
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                string limit = response.Headers["rbx-authentication-ticket"].ToString();
                return limit;
            }
        }
        static void VisitBot(long hu)
        {
            string auth_ticket = Grab_Auth_Ticket(hu);
            Random rn = new Random();
            int Randomm = rn.Next(1000000, 10000000);
            string url = "roblox-player:1+launchmode:play+gameinfo:" + auth_ticket + "+launchtime:" + Randomm + "+placelauncherurl:https%3A%2F%2Fassetgame.roblox.com%2Fgame%2FPlaceLauncher.ashx%3Frequest%3DRequestGame%26browserTrackerId%3D" + Randomm + "%26placeId%3D" + hu + "%26isPlayTogetherGame%3Dfalse+browsertrackerid:" + Randomm + "+robloxLocale:en_us+gameLocale:en_us";
            System.Diagnostics.Process.Start(url);
        }

        static void Main(string[] args)
        {
            int Value = 0;
            Console.WriteLine("Whats Your Game ID?");
            string Input = Console.ReadLine();
            long a;
            a = long.Parse(Input);
            Console.Title = "Visits Given " + Value;
            bool oof = true;
            while (oof == true)
            {
              
           
                  
                        System.Threading.Thread.Sleep(10000);
                        Value++;
                        VisitBot(a);
                Console.Title = "Visits Given " + Value;


            }
        }

        }
    }

