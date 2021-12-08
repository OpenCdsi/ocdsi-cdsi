namespace Utility
{
    public static class Enum
    {
        public static T TryParse<T>(string s)
        {
            try
            {
                return (T)System.Enum.Parse(typeof(T), s);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
