using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters;
using ArdalisRating.Infrastructure.Logger;
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
            IBatchLogger logger = new InMemoryLogger();

            // Act
            var result = factory.Create(
                policy,
                logger);

            // Assert
            Assert.NotNull(result);
        }
    }
}
