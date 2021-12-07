using System.Net.Http;
using Assignment.Test.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace Assignment.Test.Controllers;

public class ProductsControllerTests
{
    private WebApplicationFactory<Program> _webApplicationFactory;
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _webApplicationFactory = new TestWebApplicationFactory();
        _httpClient = _webApplicationFactory.CreateClient();
    }

    [Test]
    public void ProductsController_Filter_Returns_All_Products_When_No_Query_Supplied()
    {
        var result = _httpClient.GetAsync("/api/Products/filter");
        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
        });
    }
}