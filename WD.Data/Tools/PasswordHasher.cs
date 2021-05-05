using System.Security.Cryptography;
using System.Text;

namespace WD.Data.Tools
{
    public static class PasswordHasher
    {
        private static MD5 _MD5 = new MD5CryptoServiceProvider();
        public static string GetHashedPassword(string password)
        {
            byte[] source = Encoding.UTF8.GetBytes(password);
            byte[] target = _MD5.ComputeHash(source);
            string result = null;

            for (int i = 0; i < target.Length; i++)
            {
                result += target[i].ToString("x2");
            }
            return result;
        }
    }
}
