using Assignment.Models;

namespace Assignment.Domain;

public class FilterResult
{
    public FilterResult(List<Product> products):this()
    {
        Products = products;
        MostCommonWords = new string[10];
    }

    public FilterResult()
    {
        
    }
    public decimal MinimumPrice { get; set; }
    public decimal MaximumPrice { get; set; }
    public string[] Sizes { get; set; }
    public string[] MostCommonWords { get; set; }
    public List<Product> Products { get; set; } 
}