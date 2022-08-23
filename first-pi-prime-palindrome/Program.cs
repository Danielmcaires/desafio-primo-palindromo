using RestSharp;
using System;
using System.Diagnostics;
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
            int startingDecimal = 0;
            bool primePalindromeFound = false;

            while (!primePalindromeFound)
            {
                string url = "https://api.pi.delivery/v1/pi?start=" + startingDecimal + "&numberOfDigits=1000&radix=10";
                startingDecimal += 980;
                var client = new RestClient(url);

                var response = client.Execute<ApiResponse>(new RestRequest());

                if (response.IsSuccessful)
                {
                    var piInterval = response.Data;
                    Console.WriteLine("Checking palindrome in position" + startingDecimal + "of Pi decimals");
                }

                bool isPiFound = program.LookForPrimePalindrome(piInterval?);

                if (isPiFound) primePalindromeFound = true;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

        }

    }
}
