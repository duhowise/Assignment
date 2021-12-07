using Assignment.Models;

namespace Assignment.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IHttpClientFactory httpClientFactory,ILogger<ProductService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("ProductClient");
        var request = new HttpRequestMessage(HttpMethod.Get, "v2/5e307edf3200005d00858b49");
         using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        response.EnsureSuccessStatusCode();

        var data = response.Content.ReadAsStringAsync();
        var serviceContract = await response.Content.ReadFromJsonAsync<ServiceContract>();
        return serviceContract?.Products ?? new List<Product>();

        #region inMemoryMock

        //var products = new List<Product>
        //    {
        //        new Product
        //        {
        //            Title = "A Red Trouser",

        //            Price = 10,

        //           Sizes = new List<Size>
        //           {
        //               Size.Small,
        //               Size.Medium,
        //               Size.Large


        //           },

        //            Description = "This trouser perfectly pairs with a green shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Green Trouser",

        //            Price = 11,

        //           Sizes = new List<Size>()
        //           {
        //               Size.Small

        //           }
        //           ,

        //            Description = "This trouser perfectly pairs with a blue shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Blue Trouser",

        //            Price = 12,

        //           Sizes = new List<Size>
        //           {
        //               Size.Medium

        //           }
        //           ,

        //            Description = "This trouser perfectly pairs with a red shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Red Trouser",

        //            Price = 13,

        //           Sizes = new List<Size>()
        //           {
        //               Size.Large

        //           }
        //           ,

        //            Description = "This trouser perfectly pairs with a green shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Green Trouser",

        //            Price = 14,

        //           Sizes = new List<Size>()
        //           {
        //               Size.Small,

        //               Size.Medium
        //           }

        //               ,

        //            Description = "This trouser perfectly pairs with a blue shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Blue Trouser",

        //            Price = 15,

        //           Sizes = new List<Size>()
        //           {
        //               Size.Small,

        //               Size.Large
        //           }

        //               ,

        //            Description = "This trouser perfectly pairs with a red shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Red Trouser",

        //            Price = 16,

        //           Sizes = new List<Size>()
        //           {
        //               Size.Medium,

        //               Size.Large
        //           }

        //               ,

        //            Description = "This trouser perfectly pairs with a green shirt."
        //        },

        //        new Product
        //        {
        //            Title = "A Green Trouser",

        //            Price = 17,

        //            Sizes = new List<Size>(),

        //            Description = "This trouser perfectly pairs with a blue shirt."
        //        }
        //    };
        //return await Task.FromResult(products);

        #endregion

    }
}