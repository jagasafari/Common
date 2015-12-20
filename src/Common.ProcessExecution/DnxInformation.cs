namespace Common.ProcessExecution
{
    using System.IO;

    public static class DnxInformation
    {
        private const string DnuProgramName = "dnu.cmd";

        public static string DnxPath
            =>
                @"C:\Users\mika\.dnx\runtimes\dnx-clr-win-x86.1.0.0-rc1-final\bin\dnx.exe";

        public static string DnuPath => Path.Combine(DnxDirectory, DnuProgramName);

        private static string DnxDirectory
            => Path.GetDirectoryName(DnxPath);
    }
}