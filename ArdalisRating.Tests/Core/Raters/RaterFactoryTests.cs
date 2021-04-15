using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters;
using ArdalisRating.Tests.Fakes;
using Xunit;

namespace ArdalisRating.Tests.Core.Raters
{
    public class RaterFactoryTests
    {
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = new RaterFactory();
            PolicyModel policy = new();
            ILogger logger = new FakeLogger();

            // Act
            var result = factory.Create(
                policy,
                logger);

            // Assert
            Assert.NotNull(result);
        }
    }
}
