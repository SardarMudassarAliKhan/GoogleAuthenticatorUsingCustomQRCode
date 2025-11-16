using OtpNet;

namespace WebApplication1.Helper
{
    public static class TotpHelper
    {
        public static string GenerateSecretKey()
        {
            var bytes = KeyGeneration.GenerateRandomKey(20);
            return Base32Encoding.ToString(bytes);
        }

        public static string GenerateTotp(string base32Secret)
        {
            var bytes = Base32Encoding.ToBytes(base32Secret);
            var totp = new Totp(bytes);
            return totp.ComputeTotp();
        }

        public static bool ValidateCode(string base32Secret, string code)
        {
            var bytes = Base32Encoding.ToBytes(base32Secret);
            var totp = new Totp(bytes);
            return totp.VerifyTotp(code, out long timeWindowUsed, VerificationWindow.RfcSpecifiedNetworkDelay);
        }
    }
}