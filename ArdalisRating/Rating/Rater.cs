using ArdalisRating.Logger;
using ArdalisRating.Policy;

namespace ArdalisRating.Rating
{
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }
    public class RatingUpdater : IRatingUpdater
    {
        private readonly RatingEngine _engine;

        public RatingUpdater(RatingEngine engine)
        {
            _engine = engine;
        }
        public void UpdateRating(decimal rating)
        {
            _engine.Rating = rating;
        }
    }

    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }
        public abstract void Rate(PolicyModel policy);
    }
}
