using Xunit;

namespace MyApp.Tests
{
    public class BasicTests
    {
        [Fact]
        public void TestEnvironmentIsWorking()
        {
            Assert.True(true, "Тестовое окружение работает корректно");
        }
    }
}
