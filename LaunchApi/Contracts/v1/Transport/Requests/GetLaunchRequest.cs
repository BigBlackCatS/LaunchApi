using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaunchApi.Contracts.v1.Transport.Requests
{
    public class GetLaunchRequest
    {
        [FromRoute]
        [Required(ErrorMessage = "Provide an Id of the flight, please.")]
        public string Id { get; set; }
    }
}
