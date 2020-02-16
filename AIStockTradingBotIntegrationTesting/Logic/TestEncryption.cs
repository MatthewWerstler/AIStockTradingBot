using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AIStockTradingBotLogic;

namespace WorkingMansDayTradingTests.Logic
{
    [TestClass]
    public class TestEncryption
    {
        [TestMethod]
        public void shouldBeAbleToEncryptAndDecryptAString()
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string testString = "Here is my string to test encrypting and decrypting with.";
            string encrypted = Encryption.Encrypt(EncryptionKey, testString);
            string decrypted = Encryption.Decrypt(EncryptionKey, encrypted);
            Assert.AreEqual(testString, decrypted);
            Assert.AreNotEqual(encrypted, testString);
        }
    }
}
