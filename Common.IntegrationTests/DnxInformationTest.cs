using ProcessExecution;
using Xunit;

namespace Common.IntegrationTests
{
    public class DnxInformationTest
    {
		[Fact]
		public void DnxPath_RetrivedFromProcessModule()
		{
            var path = @"C:\Users\mika\.dnx\runtimes\dnx-clr-win-x86.1.0.0-rc1-final\bin\dnx.exe";
			Assert.Equal(path, DnxInformation.DnxPath);
        }
    }
}