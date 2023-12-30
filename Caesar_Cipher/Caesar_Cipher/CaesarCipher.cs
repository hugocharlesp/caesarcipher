using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    public class CaesarCipher
    {
        public static string Encrypt(string plaintext, int shift)
        {
            char[] result = plaintext.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                {
                    char baseChar = char.IsUpper(result[i]) ? 'A' : 'a';
                    result[i] = (char)((result[i] - baseChar + shift) % 26 + baseChar);
                }
            }

            return new string(result);
        }
    }

    public class CaesarDecipher
    {
        public static string Decrypt(string ciphertext, int shift)
        {
            return CaesarCipher.Encrypt(ciphertext, 26 - shift);
        }
    }

    public class CaesarCipherApp
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to the Caesar Cipher application!");

            bool retry;
            do
            {
                retry = false;

                try
                {
                    Console.Write("Enter your message: ");
                    string message = Console.ReadLine();


                    Console.Write("Do you want to encrypt or decrypt? (E/D): ");
                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    Console.Write("Enter the shift (key): ");
                    if (!int.TryParse(Console.ReadLine(), out int shift))
                    {
                        Console.WriteLine("Error: Please enter an integer for the shift.");
                        retry = true; 
                        continue;
                    }

                    if (choice == 'E' || choice == 'e')
                    {
                        string ciphertext = CaesarCipher.Encrypt(message, shift);
                        Console.WriteLine($"Encrypted message: {ciphertext}");
                    }
                    else if (choice == 'D' || choice == 'd')
                    {
                        string decryptedText = CaesarDecipher.Decrypt(message, shift);
                        Console.WriteLine($"Decrypted message: {decryptedText}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please choose E to encrypt or D to decrypt.");
                        retry = true; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    retry = true; 
                }
            } while (retry);
        }
    }
}
