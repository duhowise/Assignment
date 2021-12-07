using Assignment.Extensions;
using Assignment.Services;
using MediatR;

namespace Assignment.Domain.Products;

public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, FilterResult>
{
    private readonly ILogger<SearchProductQueryHandler> _logger;
    private readonly IProductService _productService;

    public SearchProductQueryHandler(ILogger<SearchProductQueryHandler> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<FilterResult> Handle(SearchProductQuery? request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetProductsAsync();
        if (request is null)
            return new FilterResult
            {
                Products = products
            };

        if (!request.IsValid())
            return new FilterResult
            {
                Products = products
            };
        var highLights = request.Highlight.Split(',');

        var filteredProducts = products
            .Where(x => x.Price <= request?.MaxPrice)
            .Where(x => x.Sizes.Contains(request.Size))
            .Where(x => highLights.Any(highLight => x.Description.Contains(highLight))).ToList();

        var maxPrice = filteredProducts.Max(x => x.Price);
        var minPrice = filteredProducts.Min(x => x.Price);

        var allProductSizes = filteredProducts.GetAllProductSizes();
        var allWordsInDescriptionsFromFilteredProducts = filteredProducts.WordsInProductDescription();
        var mostCommonWords = allWordsInDescriptionsFromFilteredProducts.MostCommonWords().ToArray();
        var mostCommonWordsExceptFive = mostCommonWords.MostCommonWordsExcept(5);
        var productsWithHighlightedText = filteredProducts.Select(x =>
        {
            x.Description = x.Description.AddHtmlTags(highLights);
            return x;
        }).ToList();

        var filtered = new FilterResult
        {
            MaximumPrice = maxPrice,
            Sizes = allProductSizes,
            Products = productsWithHighlightedText,
            MinimumPrice = minPrice,
            MostCommonWords = mostCommonWordsExceptFive
        };

        return filtered;
    }
}