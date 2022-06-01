using System;
using NUnit.Framework;


namespace Lab
{
    [TestFixture]
    public class EncryptionTest
    {
        [Test]
        public void SimpleDecodeAndDecode()
        {
            Encryption rsaEncryptor = new Encryption(5, 71);
            string result = rsaEncryptor.RSA_Decode(rsaEncryptor.RSA_Encode("привет мир"));
            Assert.AreEqual("ПРИВЕТ МИР", result);
        }
        [Test]
        public void EmptyDecodeAndDecode()
        {
            Encryption rsaEncryptor = new Encryption(5, 71);
            string result = rsaEncryptor.RSA_Decode(rsaEncryptor.RSA_Encode(""));
            Assert.AreEqual("", result);
        }
        [Test]
        public void SpacesDecodeAndDecode()
        {
            Encryption rsaEncryptor = new Encryption(7, 113);
            string result = rsaEncryptor.RSA_Decode(rsaEncryptor.RSA_Encode("     "));
            Assert.AreEqual("     ", result);
        }
        [Test]
        public void DigitsDecodeAndDecode()
        {
            Encryption rsaEncryptor = new Encryption(11, 29);
            string result = rsaEncryptor.RSA_Decode(rsaEncryptor.RSA_Encode("1234567890"));
            Assert.AreEqual("1234567890", result);
        }
        [Test]
        public void ComplexDecodeAndDecode()
        {
            Encryption rsaEncryptor = new Encryption(53, 101);
            string result = rsaEncryptor.RSA_Decode(rsaEncryptor.RSA_Encode("Привет, Мир! 123"));
            Assert.AreEqual("ПРИВЕТ, МИР! 123", result);
        }
    }
}