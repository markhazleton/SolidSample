using ArdalisRating.Infrastructure.Logger;
using System;
using Xunit;

namespace ArdalisRating.Tests.Infrastructure.Logger
{
    public class ConsoleLoggerTests
    {
        [Fact]
        public void Log_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var consoleLogger = new ConsoleLogger();
            string message = null;

            // Act
            consoleLogger.Log(message);

            // Assert
            Assert.Null(message);
        }
    }
}
