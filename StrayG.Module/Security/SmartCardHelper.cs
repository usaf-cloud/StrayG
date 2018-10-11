using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;
using NLog;

namespace StrayG.Module.Security
{
    public static class SmartCardHelper
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public static bool ParseDoDCertificateSubject(string subject, out string firstName, out string middleName, out string lastName, out string DoDIdNumber)
        {
            //initialize variables
            firstName = string.Empty;
            middleName = string.Empty;
            lastName = string.Empty;
            DoDIdNumber = string.Empty;

            //set the delimiter characters
            char[] delimiterChars = { ' ', ',', '.', ':', '=' };

            //split up the subject
            string[] words = subject.Split(delimiterChars);

            try
            {
                //get the needed info
                lastName = words[1];
                firstName = words[2];
                middleName = words[3];
                DoDIdNumber = words[4];
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
            return true;
        }

        public static string SignData(string message, RSACryptoServiceProvider rsa)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            //// Write the message to a byte array using UTF8 as the encoding.
            var encoder = new UTF8Encoding();
            byte[] originalData = encoder.GetBytes(message);

            try
            {
                //// Sign the data, using SHA512 as the hashing algorithm 
                signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
            }
            catch (CryptographicException e)
            {
                _logger.Error(e);
                return null;
            }
            finally
            {
                //// Set the keycontainer to be cleared when rsa is garbage collected.
                rsa.PersistKeyInCsp = false;
            }
            //// Convert the a base64 string before returning
            return Convert.ToBase64String(signedBytes);
        }

        public static bool VerifyData(string originalMessage, string signedMessage, RSACryptoServiceProvider rsa)
        {
            bool success = false;
            var encoder = new UTF8Encoding();
            byte[] bytesToVerify = encoder.GetBytes(originalMessage);
            byte[] signedBytes = Convert.FromBase64String(signedMessage);
            try
            {
                SHA512Managed Hash = new SHA512Managed();

                byte[] hashedData = Hash.ComputeHash(signedBytes);

                success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
            }
            catch (CryptographicException e)
            {
                _logger.Error(e);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
            return success;
        }
    }
}
