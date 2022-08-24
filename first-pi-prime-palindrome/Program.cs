using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace first_pi_prime_palindrome
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            PiCalculation program = new PiCalculation();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            HttpClient client = new HttpClient();
            var piInterval = new Dictionary<string,string>();
            int startingDecimal = 0;
            bool primePalindromeFound = false;

            while (!primePalindromeFound)
            {
                string url = "https://api.pi.delivery/v1/pi?start=" + startingDecimal + "&numberOfDigits=1000&radix=10";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadAsStringAsync();
                    piInterval = JsonConvert.DeserializeObject<Dictionary<string, string>>(values);
                    Console.WriteLine("Checking palindrome starting in position " + startingDecimal + " of Pi decimals");
                    startingDecimal += 980;

                }

                bool isPiFound = program.LookForPrimePalindrome(piInterval.FirstOrDefault().Value);

                if (isPiFound) primePalindromeFound = true;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();

        }

    }
}
