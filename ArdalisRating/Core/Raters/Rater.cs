using ArdalisRating.Core.Interfaces;
using System.Collections.Generic;

namespace ArdalisRating.Core.Raters
{
    public abstract class Rater
    {
        protected readonly IBatchLogger _InMemory;

        public Rater(IBatchLogger logger)
        {
            _InMemory = logger;
        }

        public abstract decimal Rate(IPolicyModel policy);

        public List<string> GetLogList()
        {
            return _InMemory.LogList();
        }
    }
}