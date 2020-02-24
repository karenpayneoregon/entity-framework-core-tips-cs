using System;
using System.Security;
using System.Security.Cryptography;
using System.Text; // Install-Package System.Security.Cryptography.ProtectedData -Version 4.7.0

namespace SecureConnection.Classes
{
    /// <summary>
    /// Original source https://weblogs.asp.net/jongalloway/encrypting-passwords-in-a-net-app-config-file
    /// </summary>
    public class ConfigSecurity
    {
        private static readonly byte[] entropy = Encoding.Unicode.GetBytes("Well thank you for saying that");

        public static string EncryptString(SecureString input)
        {

            byte[] encryptedData = ProtectedData.Protect(
                Encoding.Unicode.GetBytes(ToInsecureString(input)), 
                entropy, 
                DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData), 
                    entropy, 
                    DataProtectionScope.CurrentUser);

                return ToSecureString(Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            var secure = new SecureString();
            foreach (var character in input)
            {
                secure.AppendChar(character);
            }

            secure.MakeReadOnly();

            return secure;

        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);

            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }

            return returnValue;
        }
    }
}
