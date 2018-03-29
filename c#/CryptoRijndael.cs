using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CMOCompliance.Common.Utility
{
    /// <summary>
    /// Cryptographic utility is used to Encrypt / Decrypt files using Rijndael(AES) algorithm with 256 bit key
    /// </summary>
    public class CryptoRijndael
    {
        public static string EncryptAndBase64(String sourceString, String password)
        {
            var keys = GetKeys(password);
            using (var memoryStream = new MemoryStream())
            {
                var rijndaelAlg = Rijndael.Create();
                using (var cryptoStream = new CryptoStream(memoryStream, rijndaelAlg.CreateEncryptor(keys.Key, keys.IV), CryptoStreamMode.Write))
                {
                    var bytes = Encoding.UTF8.GetBytes(sourceString);
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        public static string Decrypt(String base64String, String password)
        {
            var keys = GetKeys(password);
            using (var memoryStream = new MemoryStream())
            {
                var rijndaelAlg = Rijndael.Create();
                using (var cryptoStream = new CryptoStream(memoryStream, rijndaelAlg.CreateDecryptor(keys.Key, keys.IV), CryptoStreamMode.Write))
                {
                    var bytes = Convert.FromBase64String(base64String);
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// Encrypt file using Rijndael (AES) algorithm. 256 bit.        
        /// </summary>
        /// <param name="srcFileName">Input File</param>
        /// <param name="dstFileName">Encrypted File</param>
        /// <param name="password">Passphrase</param>
        /// <remarks>
        /// Input File will be deleted
        /// </remarks>
        public static void EncryptFile(String srcFileName, String dstFileName, String password)
        {
            EncrypFile(srcFileName, dstFileName, password, true);
        }

        /// <summary>
        /// Decrypt file using Rijndael (AES) algorithm. 256 bit.
        /// </summary>
        /// <param name="srcFileName">Encryped File</param>
        /// <param name="dstFileName">Decrypted File</param>
        /// <param name="password"></param>
        /// <remarks>
        /// Encryped File will be deleted
        /// </remarks>
        public static void DecryptFile(String srcFileName, String dstFileName, String password)
        {
            EncrypFile(srcFileName, dstFileName, password, false);
        }

        private static void EncrypFile(String srcFileName, String dstFileName, String password, bool isEncrypt)
        {
            var keys = GetKeys(password);

            FileStream srcStream = null;
            FileStream dstStream = null;
            CryptoStream cryptoStream = null;

            try
            {
                srcStream = File.Open(srcFileName, FileMode.Open, FileAccess.Read);
                dstStream = File.Open(dstFileName, FileMode.Create, FileAccess.Write);

                var buffer = new Byte[4096];
                long bytesProcessed = 0;
                var fileLength = srcStream.Length;

                var rijndaelAlg = Rijndael.Create();

                cryptoStream = isEncrypt
                    ? new CryptoStream(dstStream, rijndaelAlg.CreateEncryptor(keys.Key, keys.IV), CryptoStreamMode.Write)
                    : new CryptoStream(dstStream, rijndaelAlg.CreateDecryptor(keys.Key, keys.IV), CryptoStreamMode.Write);

                while (bytesProcessed < fileLength)
                {
                    var bytesIncurrentBlock = srcStream.Read(buffer, 0, buffer.Length);
                    cryptoStream.Write(buffer, 0, bytesIncurrentBlock);
                    bytesProcessed += bytesIncurrentBlock;
                }

                cryptoStream.Close();
                srcStream.Close();
                dstStream.Close();

                if (File.Exists(srcFileName))
                    File.Delete(srcFileName);
            }
            finally
            {
                if (cryptoStream != null) cryptoStream.Close();
                if (srcStream != null) srcStream.Close();
                if (dstStream != null) dstStream.Close();
            }
        }

        private static Keys GetKeys(string password)
        {
            /* Preparing data for key and input vector */
            var data = password.ToCharArray();
            var dataToHash = new byte[data.Length];
            for (var i = 0; i < data.Length; i++)
                dataToHash[i] = Convert.ToByte(data[i]);

            var sha512 = SHA512.Create();
            var result = sha512.ComputeHash(dataToHash);

            /* Generating key for algorithm */
            var key = new byte[32];
            for (var i = 0; i < key.Length; i++)
                key[i] = result[i];

            /* Generating input vector for algorithm */
            var iv = new byte[16];
            for (var i = 32; i < 32 + iv.Length; i++)
                iv[i - 32] = result[i];

            return new Keys(key, iv);
        }

        private class Keys
        {
            public Keys(byte[] key, byte[] iv)
            {
                this.key = key;
                this.iv = iv;
            }

            private readonly byte[] key;
            public byte[] Key
            {
                get { return key; }
            }

            private readonly byte[] iv;
            public byte[] IV
            {
                get { return iv; }
            }
        }
    }
}