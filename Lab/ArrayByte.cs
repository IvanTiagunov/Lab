using System;
using System.Collections.Generic;
using System.Numerics;

namespace Lab
{
    public class ArrayByte
    {
        public byte[] num;

        public ArrayByte(int intNum) //конструктор
        {
            num = BitConverter.GetBytes(intNum);
        }

        ~ArrayByte() //деструктор
        {
            Console.WriteLine($"{Decode()} has been deleted");
        }

        public byte[] GetValue()
        {
            return num;
        }

        public int Decode()
        {
            return BitConverter.ToInt32(num, 0);
        }

        #region
        public static ArrayByte operator +(ArrayByte value1, ArrayByte value2)
        {
            return new ArrayByte(value1.Decode() + value2.Decode());
        }

        public static ArrayByte operator -(ArrayByte value1, ArrayByte value2)
        {
            return new ArrayByte(value1.Decode() - value2.Decode());
        }

        public static ArrayByte operator *(ArrayByte value1, ArrayByte value2)
        {
            return new ArrayByte(value1.Decode() * value2.Decode());
        }

        public static ArrayByte operator /(ArrayByte value1, ArrayByte value2)
        {
            return new ArrayByte(value1.Decode() / value2.Decode());
        }

        public static ArrayByte operator %(ArrayByte value1, ArrayByte value2)
        {
            return new ArrayByte(value1.Decode() % value2.Decode());
        }

        public static bool operator ==(ArrayByte value1, ArrayByte value2)
        {
            return value1.Decode() == value2.Decode();
        }

        public static bool operator !=(ArrayByte value1, ArrayByte value2)
        {
            return value1.Decode() != value2.Decode();
        }

        public static bool operator >(ArrayByte value1, ArrayByte value2)
        {
            return value1.Decode() > value2.Decode();
        }

        public static bool operator <(ArrayByte value1, ArrayByte value2)
        {
            return value1.Decode() < value2.Decode();
        }
        #endregion
    }

}

