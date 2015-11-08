namespace Common
{
    using System.Diagnostics;
    using System.IO;

    public static class DnxInformation
    {
        private const int DnxProcessModuleIndex = 0;
        private const string DnuProgramName = "dnu.cmd";

        public static string DnxPath
            =>
                Process.GetCurrentProcess().Modules[DnxProcessModuleIndex]
                    .FileName;

        public static string DnuPath => Path.Combine(DnxDirectory, DnuProgramName);

        private static string DnxDirectory
            => Path.GetDirectoryName(DnxPath);
    }
}