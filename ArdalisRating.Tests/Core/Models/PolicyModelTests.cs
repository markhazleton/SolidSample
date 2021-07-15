using ArdalisRating.Core.Models;
using Xunit;

namespace ArdalisRating.Tests.Core.Models
{
    public class PolicyModelTests
    {
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var policyModel = new PolicyModel();

            // Act

            // Assert
            Assert.NotNull(policyModel);
            Assert.Equal(PolicyType.Unknown, policyModel.Type);
        }
    }
}