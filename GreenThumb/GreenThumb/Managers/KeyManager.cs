using System.Security.Cryptography;

namespace GreenThumb.Managers
{
    internal static class KeyManager
    {
        public static string GenerateEncryptionKey()
        {
            var rng = new RNGCryptoServiceProvider();

            var byteArray = new byte[16];
            rng.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }
    }
}
