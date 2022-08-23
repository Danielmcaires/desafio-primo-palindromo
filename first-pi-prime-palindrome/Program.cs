using System;
using System.Linq;
using System.Net.Http;
using System.Numerics;

namespace first_pi_prime_palindrome
{
    public class Program
    {
        public async void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string piInterval = "";
            int startingDecimal = 0;
            bool primePalindromeFound = false;
            int iteration = 0;

            while (!primePalindromeFound)
            {
                string url = "https://api.pi.delivery/v1/pi?start=" + startingDecimal + "&numberOfDigits=1000&radix=10";
                startingDecimal += 980;

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    piInterval = await response.Content.ReadAsStringAsync();
                }

                bool isPiFound = lookForPrimePalindrome(piInterval);

                if (isPiFound) primePalindromeFound = true;
            }


            //TODO INCLUIR A PARTE DE PRINTAR NO CONSOLE AS OPERAÇÕES REALIZADAS
 
        }

        public bool isPrimeNumber(BigInteger number)
        {
            int counter = 0;
            //TODO RESOLVER ESSE PROBLEMA DO RANGE. ENCONTRAR UMA ALTERNATIVA (TALVEZ PERCORRER UMA STRING?)
            foreach(BigInteger i in Enumerable.Range(1, BigInteger.Add(number, new BigInteger(1))).ToList())
            {
                if (number % 1 == 0) counter += 1;
                else if (counter > 2) break;
            }

             return (counter == 2);
        }

        public bool isPalindromeNumber(BigInteger number)
        {
            BigInteger tempValue = number;
            BigInteger reverse = 0;
            while (tempValue > 0)
            {
                reverse = reverse * 10 + tempValue % 10;
                tempValue /= 10;
            }

            return reverse == number;
        }

        public bool lookForPrimePalindrome(string piSequence)
        {
            int startPosition = 0;
            int endPosition = 21;
            bool palindrome = false;

            while (endPosition <= 1000)
            {
                var primePalindromeNumber = new BigInteger();
                primePalindromeNumber = BigInteger.Parse(piSequence.Substring(startPosition, endPosition));

                if (isPalindromeNumber(primePalindromeNumber))
                {
                    if (isPrimeNumber(primePalindromeNumber)) palindrome = true;
                    Console.WriteLine(primePalindromeNumber);
                    break;
                }

                startPosition++;
                endPosition++;
            }

            return palindrome;
        }

    }
}
