using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;
using NLog;
using System.Text.RegularExpressions;

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

        public static bool ParseDoDSmartCard2dBarcodeScan(string barcodeScan, out string uniqueIdentifier, out string rank, out string grade, out string firstName, out string middleInitial, out string lastName)
        {
            //initialize variables
            firstName = string.Empty;
            middleInitial = string.Empty;
            lastName = string.Empty;
            rank = string.Empty;
            uniqueIdentifier = string.Empty;
            grade = string.Empty;

            try
            {
                /*formats
                NBFBBAHS1D2D1HVZachary.            Auer.                     B3D0AF00LT.   MO01BBBSBCE3YR				
                NBPJO8MS15I7V84Lucas.              Erickson.                 AU5HAF00LT.   MO01BBANBCCUUA				
                NDKM154S11LK3ILRonnie.             Drisdale.                 AM6ECF00.     GS07BAD1BBF8GE				
                N74AASES14V9317William.            Wilkerson.                AU76AF00MAJ.  MO04BAUQBC11IR				
                NI01061S18KD5IUVincent.            Giacomino.                ATKQAF00MAJ.  MO04BB9TBCC41M				
                NDT8MIAS14M4C56Roy.                Lozano.                   AM3KCF00.     GS09BB45BC6CVG				
                NI7G2KDS1BNKBJMDerek.              Nguyen                    B34EAM002NDLT MO01BASDBBUDNA			
                NI9ITVMS0UROK3OJohn.               Platt.                    AT0NAF00LTCOL MO05BABLBBDSVI				
                NC1I2GQS1BIPOFCIsaac.              Scherrer.                 AVSEAF00CAPT. MO03BAT6BBVDIJ
                */
                //get rid of all periods
                barcodeScan = barcodeScan.Replace(".", " ");

                //get rid of multiple spaces in a row
                barcodeScan = Regex.Replace(barcodeScan, @"\s+", " ", RegexOptions.Multiline);

                //break string up into substrings based on a space
                string[] subStrings = barcodeScan.Split(new char[]{' '});

                //get the needed info from subStrings[0]
                uniqueIdentifier = subStrings[0].Substring(0, 15).Trim();
                firstName = subStrings[0].Substring(15).Trim();

                //get the needed info from subStrings[1]
                lastName = subStrings[1].Trim();

                //get the needed info from subStrings[2]
                rank = subStrings[2].Substring(subStrings[2].IndexOf("00")+2);
                if (rank == string.Empty) rank = "CIV";

                //get the needed info from subStrings[3]
                grade = subStrings[3].Substring(0, 4);
                middleInitial = subStrings[3].Last().ToString();
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
