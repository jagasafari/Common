namespace Common.Core
{
    using System.IO;
    public static class StringExtensions
    {
        public static string GetParentDirectory(this string fullPath, int parentLevel)
        {
            string parentPath = fullPath;
            while (parentLevel-- > 0)
                parentPath = Directory.GetParent(parentPath).FullName;
            return parentPath;
        }
    }
}