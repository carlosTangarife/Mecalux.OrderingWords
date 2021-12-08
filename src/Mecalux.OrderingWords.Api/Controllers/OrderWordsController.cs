using Mecalux.OrderingWords.Application.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace Mecalux.OrderingWords.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderWordsController : ControllerBase
    {

        private readonly ILogger<OrderWordsController> _logger;

        private readonly IOrderOptionsRepository _orderOptionsRepository;

        public OrderWordsController(ILogger<OrderWordsController> logger, IOrderOptionsRepository orderOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _orderOptionsRepository = orderOptions ?? throw new ArgumentNullException(nameof(orderOptions));
        }

        [HttpGet("GetOrderOptions")]
        [ProducesResponseType(typeof(ICollection<KeyValuePair<string, int>>), (int)HttpStatusCode.OK)]
        public IActionResult GetOrderOptions()
        {
            _logger.LogInformation("=>>>>>>>>>>>> Geting Order Options");
            return Ok(_orderOptionsRepository.GetOrderOptions());
        }
    }
}
