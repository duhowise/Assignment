using System.Text.Json.Serialization;
using Assignment.Extensions;

namespace Assignment.Models;

public class Product
{
    public string? Title { get; set; }

    public decimal Price { get; set; }

    public string[] Sizes { get; set; } = null!;

    public string Description { get; set; } = null!;
}