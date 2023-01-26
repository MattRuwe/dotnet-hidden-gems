namespace MyLibrary
{
    public static class StringExtensions
    {
        public static string ToRandomCase(this string str)
        {
            var result = "";
            var random = new Random();
            foreach (var c in str.ToCharArray())
            {
                if (random.Next(0, 2) == 0)
                {
                    result += c.ToString().ToUpper();
                }
                else
                {
                    result += c.ToString().ToLower();
                }
            }

            return result;
        }
    }
}