using ArdalisRating.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArdalisRatingWebApi.Controllers.api
{
    /// <summary>
    /// Rate API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly IRatingEngine _ratingEngine;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="policySource"></param>
        /// <param name="policySerializer"></param>
        /// <param name="ratingEngine"></param>
        public RateController(IPolicySource policySource, 
            IPolicySerializer policySerializer, 
            IRatingEngine ratingEngine)
        {
            _policySource = policySource;
            _policySerializer = policySerializer;
            _ratingEngine = ratingEngine;

        }

        /// <summary>
        /// Rate a Policy from Json string passed in
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult<decimal> Rate([FromBody] string policy)
        {
            _policySource.PolicySource = policy;
            var myPolicy = _policySerializer.GetPolicyFromString(_policySource.GetPolicyFromSource());
            _ratingEngine.Rate(myPolicy);
            if(_ratingEngine.Rating>0) 
                return _ratingEngine.Rating;

                       
            return BadRequest(_ratingEngine.GetLogMessage());

        }
    }
}
