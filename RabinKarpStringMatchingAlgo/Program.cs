using System;
using System.Collections;

namespace RabinKarpStringMatchingAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringForSeaching = "sddsssasasdsadsdadsdsasdasd";


            //getHashCodeOfString("ab", 10);
            RabinKarpStringMathc("asd", stringForSeaching);

            Console.WriteLine(RabinKarpStringMathc("asd", stringForSeaching));
            Console.ReadKey();
        }

        static int getHashCodeOfString(string s, int numberOfCharFactor)
        {
            int code = 0;
            int helper = s.Length - 1;
            foreach(char c in s)
            {
                code += (int)Math.Pow(numberOfCharFactor, helper) * (int)c;
                helper--;
            }
            return code;
        }

        static int RabinKarpStringMathc(string pattern, string stringForSearching)
        {
            int hashCode = getHashCodeOfString(pattern, 10);
            int counter = 0;
            string startinSubstring = stringForSearching.Substring(counter, pattern.Length);
            int startingHashCode = getHashCodeOfString(startinSubstring, 10);
            var stringForSearchingArr = stringForSearching.ToCharArray();

            int endingPosition = pattern.Length - 1;
            while(endingPosition <= stringForSearching.Length)
            {
                if (startingHashCode == hashCode)
                {
                    return endingPosition - pattern.Length + 1;
                }
                else
                {
                    int difference = ((int)startinSubstring[0] * ((int)Math.Pow(10, pattern.Length - 1)));
                    startingHashCode -= difference;
                    startingHashCode = startingHashCode * 10;
                    if (endingPosition + 1 == stringForSearching.Length) return -1;
                    startingHashCode += (int)stringForSearching[endingPosition + 1];
                    counter++;
                    startinSubstring = stringForSearching.Substring(counter, pattern.Length);


                }
            
                endingPosition++;
            }
            return -1;
        }
    }
}
