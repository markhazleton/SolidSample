using System;

namespace ArdalisRating.Core.Interfaces
{
    public interface IRatingEngine
    {
        void Rate();

        decimal Rating { get; set; }
    }
}
