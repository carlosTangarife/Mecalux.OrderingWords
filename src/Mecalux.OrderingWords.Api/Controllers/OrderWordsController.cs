using Mecalux.OrderingWords.Application.Contracts.Repository;
using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using Mecalux.OrderingWords.Domain.Entities;
using Mecalux.OrderingWords.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mecalux.OrderingWords.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderWordsController : ControllerBase
    {
        private readonly ILogger<OrderWordsController> _logger;
        private readonly IOrderOptionsRepository _orderOptionsRepository;
        private readonly IOrderWordsService _orderingWordsService;

        public OrderWordsController(
            ILogger<OrderWordsController> logger, 
            IOrderOptionsRepository orderOptionsRepository, 
            IOrderWordsService orderingWordsService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _orderOptionsRepository = orderOptionsRepository ?? throw new ArgumentNullException(nameof(orderOptionsRepository));
            _orderingWordsService = orderingWordsService ?? throw new ArgumentNullException(nameof(orderingWordsService));
        }

        [HttpGet("GetOrderOptions")]
        [ProducesResponseType(typeof(ICollection<KeyValuePair<string, int>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetOrderOptions()
        {
            _logger.LogInformation("Getting order options");
            
            var result = await Task.FromResult(_orderOptionsRepository.GetOrderOptions());
            
            _logger.LogInformation("Successfully retrieved {Count} order options", result.Count);
            return Ok(result);
        }

        [HttpPost("GetStatic")]
        [ProducesResponseType(typeof(TextStatistics), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetStatic([FromBody] GetStaticRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for GetStatic request");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Getting statistics for text with {Length} characters", request.TextToAnalyze.Length);
            
            // Analyze the original text without trimming to preserve user's input format
            var result = await Task.FromResult(_orderingWordsService.GetStatic(request.TextToAnalyze));
            
            _logger.LogInformation("Successfully calculated statistics: Words={Words}, Spaces={Spaces}, Hyphens={Hyphens}", 
                result.WordQuantity, result.SpacesQuantity, result.HyphensQuantity);
            
            return Ok(result);
        }

        [HttpPost("GetOrderedText")]
        [ProducesResponseType(typeof(ICollection<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetOrderedText([FromBody] GetOrderedTextRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for GetOrderedText request");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Ordering text with {Length} characters using {OrderOption} option", 
                request.TextToOrder.Length, request.OrderOptions);
            
            // For ordering, we do want to trim to avoid empty words, but preserve the analysis integrity
            var result = await Task.FromResult(_orderingWordsService.GetOrderedText(request.TextToOrder.Trim(), request.OrderOptions));
            
            _logger.LogInformation("Successfully ordered text into {Count} words", result.Count);
            return Ok(result);
        }
    }
}
