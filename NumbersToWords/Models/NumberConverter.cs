using System;
using System.Collections.Generic;

namespace NumbersToWords.Models
{
    
    public class NumberConverter
    {
        public int Number { get; set; }
        
        // NumberConverter constructor... My class constructor

        public NumberConverter(int myNum)
        {
            Number = myNum;
        }

        // Creating method that converts numbers to words
        public static string ConvertNumberToWords(long number)
        {
            if(number == 0)
            {
                return "zero";
            }
            // else Create multiple Dictionaries

            // Dictionary for units
            Dictionary<int, string> units = new Dictionary<int, string>()
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"}
            };

            Dictionary<int, string> teenMembers = new Dictionary<int, string>()
            {
                {1, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eightteen"},
                {19, "nineteen"}
            };

            Dictionary<int, string> tens = new Dictionary<int, string>()
            {
                {2, "twenty"},
                {3, "thirty"},
                {4, "forty"},
                {5, "fifty"},
                {6, "sixty"},
                {7, "seventy"},
                {8, "eighty"},
                {9, "ninety"},
            };

            Dictionary<int, string> thousands = new Dictionary<int, string>()
            {
                {0, ""},
                {1, "thousand"},
                {2, "million"},
                {3, "billion"},
                {4, "trillion"},
            };

            string result = "";

            // The first thing I did in my while loop is to: 
            // calculate the remainder when divided by 1000 (effectively extracting the last three digits), and then store these three digits in the chunk variable as an integer. This chunk will be further processed to convert it into words. The process is repeated for each set of three digits in the number.
            // e.g: given 6500, when divided by 1000, we have 6 remainder 500, by doing this we have been able to extract the last three digits from our value
            // Also, 670/1000 yields 0 remainder 670, and by doing this we have successfully been able to derive the last 3 digits of the inputted number
            // This is a static rule for all numbers; trying it for 13, 13/1000 yields 0 remainder 13, by doing this we have been able to derive the last 2 digits
            // 1100/1000 yields 1 remainder 100, we now have the last 3 digits also
            // Where chunkCount comes in is to keep track of the position, is it in tens, hundreds, thousands

            // the below is responsible for processing the input number in chunks of three digits.
            // chunkCount is used to keep track of the current chunk's position (thousands, millions, billions, etc.).
            int chunkCount = 0;

            // while loop continues as long as the remaining number is greater than zero
            while (number > 0)
            {
                // Explicitly casting the number gotten from user into an integer and dividing by a thousand
                int chunk = (int)(number % 1000);
                if (chunk > 0)
                {
                    result = ConvertChunkToWords(chunk, units, teenMembers, tens) + " " + thousands[chunkCount] + " " + result;
                }
                number /= 1000;
                chunkCount++;
            }
            // removing unneccessary whitespaces that are either leading(in front) or trailing(after) the result
            return result.Trim();

            // The loop continues until the entire number has been processed, and each chunk has been converted into words and added to the result string. The final result represents the entire number in words.

        }


        // the ConvertChunkToWords() method is responsible for converting a three-digit chunk of a number into its word representation
        // ConvertChunkToWords() method takes in 4 parameters, first is the number passed in, next 3 are dictionaries(units, teens, tens) we already defined this dictionaries above. And method also returns a string
        public static string ConvertChunkToWords(int myChunk, Dictionary<int, string> myUnits, Dictionary<int, string> myTeenMembers, Dictionary<int, string> myTens)
        {
            string result = "";

            // chunk is still the inputted number(the number variable) but its been forcefully converted to an integer
            int hundreds = myChunk / 100; // This line calculates the hundreds digit in the chunk by performing integer division. For example, if chunk is 324, hundreds will be 3. We already divided by 1000 in our while loop before we called on this method, now we're dividing by 100
            int remainder = myChunk % 100; // This line calculates the remainder after removing the hundreds digit. In the example, if chunk is 324, remainder will be 24.

            if(hundreds > 0) 
            // This condition checks if there are hundreds in the chunk. If there are, it appends the word representation of the hundreds to the result string. For example, if hundreds is 3, it appends "three hundred".... 
            // To achieve this, We used the key-value pairs defined in our units dictionary. We called on the units dictionary, passed in a key(e.g 3) and that key returns a string value: three 
            {
                result += myUnits[hundreds] + " hundred";
                if (remainder > 0)
                {
                    result += " and ";
                }
            }

            if(remainder > 0)
            {
                // if (remainder > 0): This condition checks if there is a remainder (values less than 100) in the chunk.
                if(remainder < 10)
                {
                    // if the remainder is less than 10, it appends the word representation of the myUnits to the result string.
                    // If remainder is less than 10, we know its a unit hence we use our dictionary, pass in the remainder, e.g: myUnits[2] returns "two"... Thanks to our units dictionary
                    result += myUnits[remainder];
                }
                else if (remainder < 20)
                {
                    // If the remainder is between 10 and 20, it appends the word representation of the myTeenMembers to the result string.
                    // If remainder is between 10 and 20, we know its a teen(11-19), we use our teen dictionary to return the string equivalent, eng: myTeens[13] returns "thirteen"
                    result += myTeenMembers[remainder];
                }
                else
                {
                    // The remainder is greater than or equal to 20, it calculates the tens digit and units digit separately. It then appends the word representation of the myTens and myUnits to the result string.
                    // If remainder is greater than or equal to 20, looking at our tens dictionary, we know that such numbers are in the tens
                    // We now perform tens digits and units digits separately, and append its result. E.g: 24; it has both a tens value of 20 and a units value of 4.. We used the modulo operator(remainder) to find units value. We also used the divided by 10 to get the tens value
                    int tensDigit = remainder / 10;
                    int unitsDigit = remainder % 10;

                    result += myTens[tensDigit];
                    // After getting the tens value, if units still exists, we would also like to get thatone too
                    if(unitsDigit > 0)
                    {
                        result += " " + myUnits[unitsDigit];
                    }
                }
            }

            return result;
            // The result string is gradually built up based on the hundreds, tens, and units in the chunk, and it is returned as the word representation of that particular three-digit chunk. This method is called multiple times when processing the entire number, and each chunk contributes to the final representation of the number in words.
        } 



         

        
    }
}
