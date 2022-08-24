using System;
using System.Linq;

namespace first_pi_prime_palindrome
{
    public class PiCalculation
    {
        public bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }

        public bool IsPrimeNumber(int number)
        {

            int counter = 0;
            foreach (int i in Enumerable.Range(1, number + 1))
            {
                if (number % i == 0) counter ++;
                else if (counter > 2) break;
            }

            return counter == 2;
        }

        public bool IsPalindromeNumber(int number)
        {
            int tempValue = number;
            int reverse = 0;
            while (tempValue > 0)
            {
                reverse = reverse * 10 + tempValue % 10;
                tempValue /= 10;
            }

            return reverse == number;
        }

        public bool LookForPrimePalindrome(string piSequence)
        {
            int startPosition = 0;
            int endPosition = 9;
            bool primePalindrome = false;

            while (startPosition <= 991 && !primePalindrome)
            {
                int primePalindromeNumber = int.Parse(piSequence.Substring(startPosition, endPosition));

                if (IsPalindromeNumber(primePalindromeNumber))
                {
                    Console.WriteLine("Palindrome found: " + primePalindromeNumber);
                    if (!IsEvenNumber(primePalindromeNumber))
                    { 
                        if (IsPrimeNumber(primePalindromeNumber)){
                            primePalindrome = true;
                            Console.WriteLine("prime Palindrome found: " + primePalindromeNumber);
                        }
                        else {
                            Console.WriteLine("But it is not a prime :/ ");
                            Console.WriteLine("\n");
                        }
                    }
                }

                if (primePalindrome) break;
                startPosition++;
            }

            return primePalindrome;
        }
    }
}
