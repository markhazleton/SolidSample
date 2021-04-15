using System;
using ArdalisRating.Core.Models;

namespace ArdalisRating.Core.Interfaces
{
    public interface IPolicyModel
    {
        string Address { get; set; }
        decimal Amount { get; set; }
        decimal BondAmount { get; set; }
        DateTime DateOfBirth { get; set; }
        decimal Deductible { get; set; }
        int ElevationAboveSeaLevelFeet { get; }
        string FullName { get; set; }
        bool IsSmoker { get; set; }
        string Make { get; set; }
        int Miles { get; set; }
        string Model { get; set; }
        decimal Size { get; set; }
        PolicyType Type { get; set; }
        decimal Valuation { get; set; }
        int Year { get; set; }
    }
}
