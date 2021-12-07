using System.Net.Http;
using Assignment.Services;
using Moq;
using NUnit.Framework;

namespace Assignment.Test.Services;
[TestFixture]
public class ProductServiceTests
{
    private ProductService _productService;
    private Mock<IHttpClientFactory> _httpClientFactory;
   [SetUp] public void Setup()
    {

        _httpClientFactory=new Mock<IHttpClientFactory>();
        
    //_productService=new ProductService()
    }
}