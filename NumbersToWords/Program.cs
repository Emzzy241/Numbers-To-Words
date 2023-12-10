using System;
using System.Collections.Generic;
using NumbersToWords.Models;

namespace NumbersToWords.Models
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Convert Numbers To Words");

             Console.WriteLine("Enter a number (up to 1 trillion):");

            if (long.TryParse(Console.ReadLine(), out long number) && number >= 0 && number <= 1_000_000_000_000)
            {
                NumberConverter numConvert = new NumberConverter(500);
                string words = NumberConverter.ConvertNumberToWords(number);
                Console.WriteLine($"Number in words: {words}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number up to 1 trillion.");
            }
        }
    }
}


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Enter a number (up to 1 trillion):");

//         if (long.TryParse(Console.ReadLine(), out long number) && number >= 0 && number <= 1_000_000_000_000)
//         {
//             NumberConverter numConvert = new NumberConverter();
//             string words = NumberConverter.ConvertNumberToWords(number);
//             Console.WriteLine($"Number in words: {words}");
//         }
//         else
//         {
//             Console.WriteLine("Invalid input. Please enter a non-negative number up to 1 trillion.");
//         }
//     }

    // static string ConvertNumberToWords(long number)
    // {
    //     if (number == 0)
    //     {
    //         return "zero";
    //     }

    //     Dictionary<int, string> units = new Dictionary<int, string>
    //     {
    //         { 1, "one" },
    //         { 2, "two" },
    //         { 3, "three" },
    //         { 4, "four" },
    //         { 5, "five" },
    //         { 6, "six" },
    //         { 7, "seven" },
    //         { 8, "eight" },
    //         { 9, "nine" }
    //     };

    //     Dictionary<int, string> teens = new Dictionary<int, string>
    //     {
    //         { 10, "ten" },
    //         { 11, "eleven" },
    //         { 12, "twelve" },
    //         { 13, "thirteen" },
    //         { 14, "fourteen" },
    //         { 15, "fifteen" },
    //         { 16, "sixteen" },
    //         { 17, "seventeen" },
    //         { 18, "eighteen" },
    //         { 19, "nineteen" }
    //     };

    //     Dictionary<int, string> tens = new Dictionary<int, string>
    //     {
    //         { 2, "twenty" },
    //         { 3, "thirty" },
    //         { 4, "forty" },
    //         { 5, "fifty" },
    //         { 6, "sixty" },
    //         { 7, "seventy" },
    //         { 8, "eighty" },
    //         { 9, "ninety" }
    //     };

    //     Dictionary<int, string> thousands = new Dictionary<int, string>
    //     {
    //         { 0, "" },
    //         { 1, "thousand" },
    //         { 2, "million" },
    //         { 3, "billion" },
    //         { 4, "trillion" }
    //         // Add more if needed
    //     };

    //     string result = "";

    //     int chunkCount = 0;
    //     while (number > 0)
    //     {
    //         int chunk = (int)(number % 1000);
    //         if (chunk > 0)
    //         {
    //             result = ConvertChunkToWords(chunk, units, teens, tens) + " " + thousands[chunkCount] + " " + result;
    //         }
    //         number /= 1000;
    //         chunkCount++;
    //     }

    //     return result.Trim();
    // }

    // static string ConvertChunkToWords(int chunk, Dictionary<int, string> units, Dictionary<int, string> teens, Dictionary<int, string> tens)
    // {
    //     string result = "";

    //     int hundreds = chunk / 100;
    //     int remainder = chunk % 100;

    //     if (hundreds > 0)
    //     {
    //         result += units[hundreds] + " hundred";
    //         if (remainder > 0)
    //         {
    //             result += " and ";
    //         }
    //     }

    //     if (remainder > 0)
    //     {
    //         if (remainder < 10)
    //         {
    //             result += units[remainder];
    //         }
    //         else if (remainder < 20)
    //         {
    //             result += teens[remainder];
    //         }
    //         else
    //         {
    //             int tensDigit = remainder / 10;
    //             int unitsDigit = remainder % 10;

    //             result += tens[tensDigit];
    //             if (unitsDigit > 0)
    //             {
    //                 result += " " + units[unitsDigit];
    //             }
    //         }
    //     }

    //     return result;
    // }
