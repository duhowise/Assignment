using Assignment.Models;
using MediatR;

namespace Assignment.Domain.Products;

public class SearchProductQuery:IRequest<FilterResult>
{

    public string? Size { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Highlight { get; set; }
}