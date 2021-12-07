using Assignment.Domain.Products;
using Assignment.Models;

namespace Assignment.Extensions;

public static class ExtensionMethods
{
    public static string[] MostCommonWords(this IEnumerable<string> words)
    {
        var nameGroup = words.GroupBy(x => x).ToList();
        var maxCount = nameGroup.Max(grouping => grouping.Count());
        return nameGroup.Where(grouping => grouping.Count() == maxCount).Select(grouping => grouping.Key).ToArray();
    }
    
    public static string[] MostCommonWordsExcept(this IEnumerable<string> words, int take)
    {
        var wordList = words as string[] ?? words.ToArray();
        var five = wordList.Take(take);
        return wordList.Except(five).ToArray();
    }

     
    public static string[] WordsInProductDescription(this IEnumerable<Product> products)
    {
        var productDescriptions = products.Select(x => x.Description).ToList();
        return productDescriptions.SelectMany(x => x.Split(' ')).ToArray();
    }

    public static string[] GetAllProductSizes(this IEnumerable<Product> products)
    {
        return products.SelectMany(x => x.Sizes).Select(x => x.ToString()).Distinct().ToArray();
    }

    public static string AddHtmlTags(string productDescription, string textToHighlight)
    {
        if (string.IsNullOrWhiteSpace(productDescription)) return productDescription;
        if (string.IsNullOrWhiteSpace(textToHighlight)) return productDescription;
        if (!productDescription.Contains(textToHighlight, StringComparison.InvariantCultureIgnoreCase))
            return productDescription;

        return productDescription.Replace(textToHighlight, $"<em>{textToHighlight}</em>");
    }

    public static string AddHtmlTags(this string productDescription, IEnumerable<string> textsToHighlight)
    {
        foreach (var textToHighlight in textsToHighlight)
        {
            productDescription = AddHtmlTags(productDescription,textToHighlight);
        }

        return productDescription;
    } 
    
    public static bool IsValid(this SearchProductQuery searchProductQuery)
    {
        return !(string.IsNullOrWhiteSpace(searchProductQuery.Highlight) 
                 && searchProductQuery.MaxPrice == default &&
                 searchProductQuery.Size == null);
    }
}