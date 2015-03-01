namespace ConsoleForum.Utility
{
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordUtility
    {
        public static string Hash(string password)
        {
            var hasher = MD5.Create();

            return GetHash(hasher, password);
        }

        private static string GetHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            foreach (byte b in data)
            {
                sBuilder.Append(b.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
