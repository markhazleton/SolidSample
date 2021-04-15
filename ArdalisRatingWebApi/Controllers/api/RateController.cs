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
        private readonly IPolicySerializer _policySerializer;
        private readonly IRatingEngine _ratingEngine;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="policySerializer"></param>
        /// <param name="ratingEngine"></param>
        public RateController(IPolicySerializer policySerializer, 
            IRatingEngine ratingEngine)
        {
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
            var myPolicy = _policySerializer.GetPolicyFromString(policy);
            _ratingEngine.Rate(myPolicy);
            if(_ratingEngine.Rating>0) 
                return _ratingEngine.Rating;

                       
            return BadRequest(_ratingEngine.GetLogMessage());

        }
    }
}
