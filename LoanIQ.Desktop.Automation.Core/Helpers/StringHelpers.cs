using System;
using System.Linq;
using System.Text;

namespace LoanIQ.Desktop.Automation.Core.Helpers
{
    public static class StringHelpers
    {
        public static string GenerateNameWithSuffix(string name)
        {
            return new StringBuilder().Append(name)
                //.Append(DateTime.Now.Minute)
                //.Append(DateTime.Now.Second)
                .Append(DateTime.Now.Millisecond)
                .Append(new Random().Next(1000))
                .ToString();
        }

        public static string GenerateAlias(string name)
        {
            return name.Replace(" ", string.Empty).Replace("-", string.Empty).ToLower();
        }

        public static string RandomString(string originalString, int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return originalString + new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

    }
}
