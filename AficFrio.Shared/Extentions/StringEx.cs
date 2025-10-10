using System.Text;
using System.Text.RegularExpressions;

namespace AficFrio.Shared.Extentions
{
    public static class StringEx
    {
        public static bool EqualsNoCase(this string str1, string str2)
        {
            return str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EqualsWithCase(this string str1, string str2)
        {
            return str1.Equals(str2, StringComparison.Ordinal);
        }

        public static bool IsNullOrEmpty(this string srt)
        {
            return string.IsNullOrEmpty(srt);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool ContainsIgnoreCase(this string str1, string str2)
        {
            return str1?.IndexOf(str2, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        public static string ToBase64(this string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        public static string FromBase64(this string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }

        public static string ErrorMsg(this string erro)
        {
            var match = Regex.Match(erro, @":\s*(.+?)\s+at");
            var msg = match.Success ? match.Groups[1].Value.Trim() : "Erro desconhecido";
            return msg;
        }
    }
}
