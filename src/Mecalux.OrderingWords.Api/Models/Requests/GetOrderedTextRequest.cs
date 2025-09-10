using System.ComponentModel.DataAnnotations;
using Mecalux.OrderingWords.Applications.Enums;

namespace Mecalux.OrderingWords.Api.Models.Requests;

public class GetOrderedTextRequest
{
    [Required(ErrorMessage = "Text to order is required")]
    [StringLength(10000, ErrorMessage = "Text cannot exceed 10,000 characters")]
    [MinLength(1, ErrorMessage = "Text must contain at least 1 character")]
    public string TextToOrder { get; set; } = string.Empty;

    [Required(ErrorMessage = "Order option is required")]
    [EnumDataType(typeof(OrderOptions), ErrorMessage = "Invalid order option")]
    public OrderOptions OrderOptions { get; set; }
}
