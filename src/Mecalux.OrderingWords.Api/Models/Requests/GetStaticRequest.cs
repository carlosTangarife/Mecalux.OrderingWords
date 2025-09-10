using System.ComponentModel.DataAnnotations;

namespace Mecalux.OrderingWords.Api.Models.Requests;

public class GetStaticRequest
{
    [Required(ErrorMessage = "Text to analyze is required")]
    [StringLength(10000, MinimumLength = 1, ErrorMessage = "Text must be between 1 and 10,000 characters")]
    public string TextToAnalyze { get; set; } = string.Empty;
}
