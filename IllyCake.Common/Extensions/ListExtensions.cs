namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> item)
        {
            return item == null || item.Count == 0;
        }

        public static bool IsNotEmpty<T>(this IList<T> item)
        {
            return !item.IsNullOrEmpty();
        }
    }
}
