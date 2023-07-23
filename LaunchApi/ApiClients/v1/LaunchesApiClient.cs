using System.Net;
using LaunchApi.Domain.Models;
using LaunchApi.SpaceXContracts.Transport.Models;
using LaunchApi.SpaceXContracts.Transport.Requests;
using Newtonsoft.Json;

namespace LaunchApi.ApiClients.v1
{
    public class LaunchesApiClient : LaunchesApiClientBase, ILaunchesApiClient
    {
        public LaunchesApiClient(HttpClient httpClient)
            : base(httpClient) {
        }

        public async Task<PagedResult<Launch>> GetPastLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default)
        {
            var _pastLaunchesUrl = "query";

            var getPagedLaunchesRequest = new GetPagedLaunchesRequest
            {
                Query = new Query
                {
                    Upcoming = false
                },
                Options = new Options
                {
                    Offset = offset,
                    Limit = limit,
                    // Launces can be returned in the wrong order according to the flight number field.
                    // That's why we sort the collection of the launches by the field.
                    OrderByField = "flight_number"
                }
            };

            var response = await SendPostRequest(
                getPagedLaunchesRequest,
                _pastLaunchesUrl,
                cancellationToken);

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PagedResult<Launch>>(content);
            }

            return null;
        }

        public async Task<PagedResult<Launch>> GetUpcomingLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default)
        {
            var _upcomingLaunchesUrl = "query";

            var getPagedLaunchesRequest = new GetPagedLaunchesRequest
            {
                Query = new Query
                {
                    Upcoming = true
                },
                Options = new Options
                {
                    Offset = offset,
                    Limit = limit,
                    // Launces can be returned in the wrong order according to the flight number field.
                    // That's why we sort the collection of the launches by the field.
                    OrderByField = "flight_number"
                }
            };

            var response = await SendPostRequest(
                getPagedLaunchesRequest,
                _upcomingLaunchesUrl,
                cancellationToken);

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PagedResult<Launch>>(content);
            }

            return null;
        }

        public async Task<Launch> GetLaunchAsync(string id, CancellationToken cancellationToken = default)
        {
            var launchEndpoint = id;

            var response = await SendGetRequest(
                launchEndpoint,
                cancellationToken);

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Launch>(content);
            }

            return null;
        }
    }
}
