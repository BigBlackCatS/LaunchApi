using AutoMapper;
using LaunchApi.Contracts.v1.Transport.Models;
using LaunchApi.Contracts.v1.Transport.Requests;
using LaunchApi.Contracts.v1.Transport.Responses;
using LaunchApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaunchApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2")]
    public class LaunchesController : ControllerBase
    {
        private readonly ILaunchesService _launchService;
        private readonly IMapper _mapper;

        public LaunchesController(ILaunchesService launchService, IMapper mapper)
        {
            _launchService = launchService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all the launches that will have been performed by now.
        /// </summary>
        /// <param name="cancellationToken">In case a request is cancelled, we will pass a cancellation token to call off execution of the request.</param>
        /// <returns>A collection of the past launches.</returns>
        [ProducesResponseType(typeof(PagedResult<Launch>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("past")]
        public async Task<PagedResult<Launch>> GetPastLaunchesAsync(
            [FromQuery] GetPagedPastLaunchesRequest getPagedPastLaunchesRequest,
            CancellationToken cancellationToken = default)
        {
            var pastLaunches = await _launchService.GetPastLaunchesAsync(
                (getPagedPastLaunchesRequest.PageNumber - 1) * getPagedPastLaunchesRequest.PageSize,
                getPagedPastLaunchesRequest.PageSize,
                cancellationToken);

            var response = _mapper.Map<PagedResult<Launch>>(pastLaunches);

            return response;
        }

        /// <summary>
        /// Get all the launches that will be done in the future.
        /// </summary>
        /// <param name="cancellationToken">In case a request is cancelled, we will pass a cancellation token to call off execution of the request.</param>
        /// <returns>A collection of the upcoming launches.</returns>
        [ProducesResponseType(typeof(PagedResult<Launch>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("upcoming")]
        public async Task<PagedResult<Launch>> GetUpcomingLaunchesAsync(
            [FromQuery] GetPagedUpcomingLaunchesRequest getPagedUpcomingLaunchesRequest,
            CancellationToken cancellationToken = default)
        {
            var upcomingLaunches = await _launchService.GetUpcomingLaunchesAsync(
                (getPagedUpcomingLaunchesRequest.PageNumber - 1) * getPagedUpcomingLaunchesRequest.PageSize,
                getPagedUpcomingLaunchesRequest.PageSize,
                cancellationToken);

            var response = _mapper.Map<PagedResult<Launch>>(upcomingLaunches);

            return response;
        }

        /// <summary>
        /// Get a launch by the specified id.
        /// </summary>
        /// <param name="id">A flight number.</param>
        /// <param name="cancellationToken">In case a request is cancelled, we will pass a cancellation token to call off execution of the request.</param>
        /// <returns>A specific launch.</returns>
        [ProducesResponseType(typeof(GetPastLaunchesResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{Id}")]
        public async Task<GetLaunchResponse> GetLauncheAsync([FromRoute] GetLaunchRequest getLaunchRequest, CancellationToken cancellationToken = default)
        {
            var launch = await _launchService.GetLaunchAsync(getLaunchRequest.Id, cancellationToken);

            var response = new GetLaunchResponse
            {
                Launch = _mapper.Map<Launch>(launch)
            };

            return response;
        }
    }
}
