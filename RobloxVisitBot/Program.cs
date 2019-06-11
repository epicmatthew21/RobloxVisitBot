using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobloxVisitBot
{
    class Program
    {
        static void VisitBot(long hu)
        {
            System.Net.WebClient wb = new System.Net.WebClient();
            string text = System.IO.File.ReadAllText("Cookie.txt");

            string Cookie = ".ROBLOSECURITY=" + text;
            wb.Headers["Cookie"] = Cookie;
            wb.Headers["User-Agent"] = "Roblox/WinInet";
            wb.Headers["Referer"] = "https://www.roblox.com/develop";
            wb.Headers["RBX-For-Gameauth"] = "true";
            string auth_ticket = wb.DownloadString("https://www.roblox.com/game-auth/getauthticket");
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
            a = Convert.ToInt64(Input.ToString());
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

