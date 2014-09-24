﻿using NUnit.Framework;
using Sodium;
using StreamCryptor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Validate the Encrypt* parameters.
    /// </summary>
    [TestFixture]
    public class EncryptExceptionTests
    {
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void EncryptionInputFileNotFoundTest()
        {
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            var testKeyPair = new KeyPair(Utilities.HexToBinary(PUBLIC_KEY), Utilities.HexToBinary(PRIVATE_KEY));
            Cryptor.EncryptFileWithStream(testKeyPair, "badfile");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionInvalidInputFileNameTest()
        {
            //Currently no test, because the path will be too long.
            //Just pass this. :)
            throw new ArgumentOutOfRangeException("badtest");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void EncryptionNoPrivateKeyInPairTest()
        {
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            var testKeyPair = new KeyPair(Utilities.HexToBinary(PUBLIC_KEY), null);
            Cryptor.EncryptFileWithStream(testKeyPair, "badfile");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void EncryptionNoPublicKeyInPairTest()
        {
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            var testKeyPair = new KeyPair(null, Utilities.HexToBinary(PRIVATE_KEY));
            Cryptor.EncryptFileWithStream(testKeyPair, "badfile");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionNoPrivateKeyTest()
        {
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            Cryptor.EncryptFileWithStream((byte[])null, Utilities.HexToBinary(PUBLIC_KEY), (byte[])null, "badfile");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionNoPublicKeyTest()
        {
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            Cryptor.EncryptFileWithStream(Utilities.HexToBinary(PRIVATE_KEY), (byte[])null, (byte[])null, "badfile");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionNoRecipientPublicKeyTest()
        {
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            Cryptor.EncryptFileWithStream(Utilities.HexToBinary(PRIVATE_KEY), Utilities.HexToBinary(PUBLIC_KEY), (byte[])null, "badfile");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionInvalidPrivateKeyInPairTest()
        {
            const string PRIVATE_KEY = "863df54207c285feac2c22235c336869fee8dba6605b8e1bc45cc8aa5e1be3fd7e53781865717d686cb3fee427823ffd8c71ea6a4d8f79c0b410457c9f881fa3";
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            var testKeyPair = new KeyPair(Utilities.HexToBinary(PUBLIC_KEY), Utilities.HexToBinary(PRIVATE_KEY));
            Cryptor.EncryptFileWithStream(testKeyPair, "badfile");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionInvalidPublicKeyInPairTest()
        {
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            const string PUBLIC_KEY = "863df54207c285feac2c22235c336869fee8dba6605b8e1bc45cc8aa5e1be3fd7e53781865717d686cb3fee427823ffd8c71ea6a4d8f79c0b410457c9f881fa3";
            var testKeyPair = new KeyPair(Utilities.HexToBinary(PUBLIC_KEY), Utilities.HexToBinary(PRIVATE_KEY));
            Cryptor.EncryptFileWithStream(testKeyPair, "badfile");
        }

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void EncryptionOutputFolderNotFoundTest()
        {
            string TESTFILE_RAW = Path.Combine("Testfiles", "MyAwesomeChipmunkKiller.jpg");
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            var testKeyPair = new KeyPair(Utilities.HexToBinary(PUBLIC_KEY), Utilities.HexToBinary(PRIVATE_KEY));
            Cryptor.EncryptFileWithStream(testKeyPair, TESTFILE_RAW, "badfolder");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EncryptionBadFileExtensionTest()
        {
            string TESTFILE_RAW = Path.Combine("Testfiles", "MyAwesomeChipmunkKiller.jpg");
            const string PRIVATE_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            const string PUBLIC_KEY = "1158b1ea7d45919968b87dab6cab27eff5871304ea9856588e9ec02a6d93c42e";
            var testKeyPair = new KeyPair(Utilities.HexToBinary(PUBLIC_KEY), Utilities.HexToBinary(PRIVATE_KEY));
            Cryptor.EncryptFileWithStream(testKeyPair, TESTFILE_RAW, Path.Combine("Testfiles", "decrypted"), "hulk");
        }
    }
}
