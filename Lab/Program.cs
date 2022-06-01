using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = 0;
            var q = 0;

            while (true)
            {
                Console.WriteLine("Введите простое число P:");
                p = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите простое число Q:");
                q = Int32.Parse(Console.ReadLine());

                if (Encryption.IsPrime(p) && Encryption.IsPrime(q))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(
                        "Пожалуйста, убедитесь в правильности введенных простых чисел");
                }
            }

            var message = "";
            StreamReader sr = new StreamReader("txt.txt");

            while (!sr.EndOfStream)
            {
                message += sr.ReadLine();
            }

            sr.Close();

            message = message.ToUpper();
            Encryption rsaEncryptor = new Encryption(p, q);
            Console.WriteLine($"Ваши секретный ключи: \ne_:{rsaEncryptor.GetE_()} \nn:{rsaEncryptor.GetN()}");

            Console.WriteLine("Исходное сообщение:");
            Console.WriteLine(message);

            var encoded = rsaEncryptor.RSA_Encode(message);
            Console.WriteLine("Зашифрованное сообщение:");
            encoded.ForEach(Console.Write);

            Console.WriteLine("\nРасшифрованное сообщение:");
            Console.WriteLine(rsaEncryptor.RSA_Decode(encoded));
        }
    }
}
