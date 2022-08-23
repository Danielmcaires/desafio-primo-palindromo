using System;
using System.Linq;

namespace first_pi_prime_palindrome
{
    public class PiCalculation
    {
        public bool IsPrimeNumber(int number)
        {
            int counter = 0;
            foreach (int i in Enumerable.Range(1, number + 1))
            {
                if (number % 1 == 0) counter += 1;
                else if (counter > 2) break;
            }

            return (counter == 2);
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
            int endPosition = 21;
            bool palindrome = false;

            while (endPosition <= 1000)
            {
                int primePalindromeNumber = int.Parse(piSequence.Substring(startPosition, endPosition));

                if (IsPalindromeNumber(primePalindromeNumber))
                {
                    if (IsPrimeNumber(primePalindromeNumber)) palindrome = true;
                    Console.WriteLine("prime Palindrome found: " + primePalindromeNumber);
                    break;
                }

                startPosition++;
                endPosition++;
            }

            return palindrome;
        }
    }
}
