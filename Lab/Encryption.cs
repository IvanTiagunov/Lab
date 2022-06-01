using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Encryption
    {
        private readonly long p;
        private readonly long q;
        private readonly long e_;
        private readonly long n;
        private readonly long m;
        private readonly long d;

        static char[] characters = new char[] {'#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж',
            'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
            'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
            'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '0', '!', '?', '.', ',', ':', ';', ')', '('};

        public Encryption(long p, long q) //конструктор
        {
            this.p = p;
            this.q = q;
            this.n = p * q;
            this.m = (p - 1) * (q - 1);
            this.d = Calculate_d(m);
            this.e_ = Calculate_e(d, m);
        }
        public long GetE_()
        {
            return e_;
        }

        public long GetN()
        {
            return n;
        }
        public static bool IsPrime(long n) //проверка на простое число
        {
            if (n < 0)
            {
                ;
                n *= -1;
            }

            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
        private long Calculate_d(long m) //Вычисление параметра d 
        {
            long d = m - 1;
            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }
            return d;
        }

        private long Calculate_e(long d, long m)//Вычисление параметра e 
        {
            long e = 10;
            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }
            return e;
        }
        public List<string> RSA_Encode(string s) //шифрование
        {
            List<string> result = new List<string>();
            s = s.ToUpper();
            BigInteger big;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);
                big = new BigInteger(index);
                big = BigInteger.Pow(big, (int)e_);

                BigInteger n_ = new BigInteger((int)n);

                big = big % n_;

                result.Add(big.ToString());
            }
            return result;
        }

        public string RSA_Decode(List<string> input) //деширование
        {
            string result = "";

            BigInteger big;

            foreach (string item in input)
            {
                big = new BigInteger(Convert.ToDouble(item));
                big = BigInteger.Pow(big, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                big = big % n_;

                int index = Convert.ToInt32(big.ToString());

                result += characters[index].ToString();
            }
            return result;
        }
    }

}
