using ArdalisRating;
using Microsoft.AspNetCore.Mvc;

namespace WebRating.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RateController : ControllerBase
{
    private readonly RatingEngine _ratingEngine;
    private readonly StringPolicySource _policySource;

    public RateController(RatingEngine ratingEngine, StringPolicySource policySource)
    {
        _ratingEngine = ratingEngine ?? throw new ArgumentNullException(nameof(ratingEngine));
        _policySource = policySource ?? throw new ArgumentNullException(nameof(policySource));
    }

    [HttpPost]
    public async Task<ActionResult<decimal>> Rate(
        [FromBody] string policy,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(policy))
        {
            return BadRequest("Policy data is required.");
        }

        _policySource.PolicyString = policy;
        await _ratingEngine.RateAsync(cancellationToken);

        return Ok(_ratingEngine.Rating);
    }
}
