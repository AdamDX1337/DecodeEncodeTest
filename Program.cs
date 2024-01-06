using System.Text;
using System;

namespace DecodeEncode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Adam Secret Chat";
            string words;
            string choice;
            Console.WriteLine("This application only supports the 26 letters of the alphabet and numbers.\nDO NOT USE SPECIAL CHARACTERS!!!\nIf you want to use commas or periods to seperate, instead use = as a comma, and + as a period.\n");

            while (true)
            {
                Console.Write("Encode or Decode (e/d):");
                choice = Console.ReadLine();

                if (choice.ToLower() == "encode" || choice.ToLower() == "e")
                {
                    Console.Write("\nType what you want to encode:");
                    words = Console.ReadLine();
                    Encode(words);
                }
                else if (choice.ToLower() == "decode" || choice.ToLower() == "d")
                {
                    Console.Write("\nType what you want to decode:");
                    words = Console.ReadLine();
                    Decode(words);
                }
            }
        }

        static void Encode(string words)
        {
            
            string originalString = words;

            Dictionary<char, char> encode = new Dictionary<char, char>
        {
            {'a', 'x'},
            {'b', 'q'},
            {'c', ' '},
            {'d', 'm'},
            {'e', 'k'},
            {'f', '2'},
            {'g', 'n'},
            {'h', 'r'},
            {'i', '9'},
            {'j', '4'},
            {'k', 'u'},
            {'l', 'v'},
            {'m', 'w'},
            {'n', '8'},
            {'o', 'a'},
            {'p', 'b'},
            {'q', 'c'},
            {'r', 'd'},
            {'s', 'e'},
            {'t', 'f'},
            {'u', 'g'},
            {'v', 'h'},
            {'w', 'i'},
            {'x', 'j'},
            {'y', 'l'},
            {'z', 'o'},
            {'0', 'y'},
            {'1', 's'},
            {'2', '7'},
            {'3', '1'},
            {'4', '5'},
            {'5', 'p'},
            {'6', '3'},
            {'7', 't'},
            {'8', '6'},
            {'9', '0'},
            {' ', 'z'},
            {'A', 'F'},
            {'B', 'X'},
            {'C', 'Q'},
            {'D', 'U'},
            {'E', 'L'},
            {'F', 'A'},
            {'G', 'K'},
            {'H', 'S'},
            {'I', 'R'},
            {'J', 'M'},
            {'K', 'P'},
            {'L', 'Y'},
            {'M', 'N'},
            {'N', 'O'},
            {'O', 'T'},
            {'P', 'Z'},
            {'Q', 'V'},
            {'R', 'W'},
            {'S', 'H'},
            {'T', 'I'},
            {'U', 'J'},
            {'V', 'B'},
            {'W', 'E'},
            {'X', 'G'},
            {'Y', 'D'},
            {'Z', 'C'},
        };

            System.Text.StringBuilder modifiedStringBuilder = new System.Text.StringBuilder();


            foreach (char c in originalString)
            {

                char mappedChar = encode.ContainsKey(c) ? encode[c] : c;

                modifiedStringBuilder.Append(mappedChar);
            }

            string modifiedString = modifiedStringBuilder.ToString();
            modifiedString = AddRandomCharacters(modifiedString);

            Console.WriteLine("Encoded String: " + modifiedString + "\n");
        }

        static void Decode(string words)
        {
            string originalString = words;

            Dictionary<char, char> decode = new Dictionary<char, char>
        {
            {'x', 'a'},
            {'q', 'b'},
            {' ', 'c'},
            {'m', 'd'},
            {'k', 'e'},
            {'2', 'f'},
            {'n', 'g'},
            {'r', 'h'},
            {'9', 'i'},
            {'4', 'j'},
            {'u', 'k'},
            {'v', 'l'},
            {'w', 'm'},
            {'8', 'n'},
            {'a', 'o'},
            {'b', 'p'},
            {'c', 'q'},
            {'d', 'r'},
            {'e', 's'},
            {'f', 't'},
            {'g', 'u'},
            {'h', 'v'},
            {'i', 'w'},
            {'j', 'x'},
            {'l', 'y'},
            {'o', 'z'},
            {'y', '0'},
            {'s', '1'},
            {'7', '2'},
            {'1', '3'},
            {'5', '4'},
            {'p', '5'},
            {'3', '6'},
            {'t', '7'},
            {'6', '8'},
            {'0', '9'},
            {'z', ' '},
            {'F', 'A'},
            {'X', 'B'},
            {'Q', 'C'},
            {'U', 'D'},
            {'L', 'E'},
            {'A', 'F'},
            {'K', 'G'},
            {'S', 'H'},
            {'R', 'I'},
            {'M', 'J'},
            {'P', 'K'},
            {'Y', 'L'},
            {'N', 'M'},
            {'O', 'N'},
            {'T', 'O'},
            {'Z', 'P'},
            {'V', 'Q'},
            {'W', 'R'},
            {'H', 'S'},
            {'I', 'T'},
            {'J', 'U'},
            {'B', 'V'},
            {'E', 'W'},
            {'G', 'X'},
            {'D', 'Y'},
            {'C', 'Z'},
        };

            System.Text.StringBuilder modifiedStringBuilder = new System.Text.StringBuilder();

            foreach (char c in originalString)
            {

                char mappedChar = decode.ContainsKey(c) ? decode[c] : c;

                modifiedStringBuilder.Append(mappedChar);
            }

            string modifiedString = modifiedStringBuilder.ToString();
            modifiedString = RemoveCharacters(modifiedString);

            Console.WriteLine("Decoded String: " + modifiedString + "\n");
        }

        static string AddRandomCharacters(string input)
        {
            Random random = new Random();

            StringBuilder modifiedStringBuilder = new StringBuilder();

            foreach (char c in input)
            {

                modifiedStringBuilder.Append(c);


                int randomNumber = random.Next(100);
                if (randomNumber > 30) // Probability of adding a special character
                {
                    char[] specialCharacters = { '!', '$', '#', '%', '&', '*' , '-' , ';', '[' , ']' , '.', ',' };
                    modifiedStringBuilder.Append(specialCharacters[random.Next(specialCharacters.Length)]);
                }
            }

            return modifiedStringBuilder.ToString();
        }
        static string RemoveCharacters(string input)
        {

            char[] specialCharacters = { '!', '$', '#', '%', '&', '*' , '-' , ';', '[' , ']' , '.', ',' };

            StringBuilder modifiedStringBuilder = new StringBuilder();

            foreach (char c in input)
            {


                if (Array.IndexOf(specialCharacters, c) == -1)
                {
                    modifiedStringBuilder.Append(c);
                }
            }

            return modifiedStringBuilder.ToString();
        }
    }
}