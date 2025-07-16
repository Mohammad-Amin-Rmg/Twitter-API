using System.Text;

namespace TwitterApi.Utilities
{
    public static class Helpers
    {
        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsValidImageExtension(string extension)
        {
            return new List<string> { ".jpg", ".jpeg", ".png", ".webp" }
                .Contains(extension.ToLower());
        }

        public static string GetAvatarPath(this string path)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            return path.Replace(root, "").Replace(@"\", "/");
        }
    }
}
