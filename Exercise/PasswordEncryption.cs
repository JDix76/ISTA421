using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security;

namespace PasswordEncryption
{
    class Program
    {
        static string Encript(string value)
        {
            using (MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = crypto.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        static SecureString astriekpw()
        {
            Console.WriteLine("Enter a username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Your Password:");
            SecureString pw = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pw.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            { return pw; }
            

        }
        static void Main(string[] args)
        {
            SecureString pw = astriekpw();
            string password = new System.Net.NetworkCredential(string.Empty, pw).Password;
            Console.WriteLine("\n The computer will encrypt and store it as" + " " + Program.Encript(password));
            Console.ReadLine();
            Console.WriteLine("The password you typed is" + "" + password);
            Console.ReadLine();

        }


    }
       
}
