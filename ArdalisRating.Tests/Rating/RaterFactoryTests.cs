using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating;
using System;
using Xunit;

namespace ArdalisRating.Tests.Rating
{
    public class RaterFactoryTests
    {
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = new RaterFactory();
            PolicyModel policy = new PolicyModel();
            IPolicyRatingContext context = new DefaultRatingContext();
            ILogger logger = new FakeLogger();

            // Act
            var result = factory.Create(
                policy,
                context,
                logger);

            // Assert
            Assert.NotNull(result);
        }
    }
}
