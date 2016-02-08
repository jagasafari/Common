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

        public static void ClearFolder(this string folderName)
        {
            var folderInfo = new DirectoryInfo(folderName);

            foreach (var fileInfo in folderInfo.GetFiles())
                fileInfo.Delete();

            foreach (var subFolderInfo in folderInfo.GetDirectories())
            {
                subFolderInfo.FullName.ClearFolder();
                subFolderInfo.Delete();
            }
        }
    }
}