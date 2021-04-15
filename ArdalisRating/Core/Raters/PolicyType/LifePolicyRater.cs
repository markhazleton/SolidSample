using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using System;

namespace ArdalisRating.Core.Raters.PolicyType
{
    public class LifePolicyRater : Rater
    {
        public LifePolicyRater(IBatchLogger logger) : base(logger)
        {
        }

        public override decimal Rate(IPolicyModel policy)
        {
            _InMemory.Log("Rating LIFE policy...");
            _InMemory.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _InMemory.Log("Life policy must include Date of Birth.");
                return 0;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _InMemory.Log("Centenarians are not eligible for coverage.");
                return 0;
            }
            if (policy.Amount == 0)
            {
                _InMemory.Log("Life policy must include an Amount.");
                return 0;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                return baseRate * 2;
            }
            return baseRate;
        }
    }
}
