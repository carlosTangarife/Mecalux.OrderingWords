using Mecalux.OrderingWords.Application.Contracts.Repository;
using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using Mecalux.OrderingWords.Domain.Entities;
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

        private readonly IOrderWordsService _orderingWordsService;

        public OrderWordsController(ILogger<OrderWordsController> logger, IOrderOptionsRepository orderOptions, IOrderWordsService orderingWordsService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _orderingWordsService = orderingWordsService ?? throw new ArgumentNullException(nameof(orderingWordsService));
            _orderOptionsRepository = orderOptions ?? throw new ArgumentNullException(nameof(orderOptions));
            _orderingWordsService = orderingWordsService ?? throw new ArgumentNullException(nameof(orderOptions));
        }

        [HttpGet("GetOrderOptions")]
        [ProducesResponseType(typeof(ICollection<KeyValuePair<string, int>>), (int)HttpStatusCode.OK)]
        public IActionResult GetOrderOptions()
        {
            _logger.LogInformation("=>>>>>>>>>>>> Geting Order Options");
            return Ok(_orderOptionsRepository.GetOrderOptions());
        }

        [HttpGet("GetStatic")]
        [ProducesResponseType(typeof(TextStatistics), (int)HttpStatusCode.OK)]
        public IActionResult GetStatic(string textToAnalize)
        {
            _logger.LogInformation("=>>>>>>>>>>>> Geting Statics");
            if (string.IsNullOrEmpty(textToAnalize))
            {
                return Ok(new TextStatistics { });
            }

            var result = _orderingWordsService.GetStatic(textToAnalize.Trim());
            return Ok(result);
        }

        [HttpGet("GetOrderedText")]
        [ProducesResponseType(typeof(ICollection<string>), (int)HttpStatusCode.OK)]
        public IActionResult GetOrderedText(string textToOrder, OrderOptions orderOptions)
        {
            _logger.LogInformation("=>>>>>>>>>>>> Geting Ordered Text");
            if (string.IsNullOrEmpty(textToOrder))
            {
                return Ok(new List<string>());
            }

            return Ok(_orderingWordsService.GetOrderedText(textToOrder.Trim(), orderOptions));
        }
    }
}
