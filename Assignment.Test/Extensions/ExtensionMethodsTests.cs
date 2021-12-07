using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Extensions;
using Assignment.Models;
using NUnit.Framework;

namespace Assignment.Test.Extensions;

[TestFixture]
public class ExtensionMethodsTests
{
    List<Product> _products;

   [SetUp] public void Setup()
    {
        _products = new List<Product>
        {
            new Product
            {
                Title = "A Red Trouser",

                Price = 10,

                Sizes = new string[]
                {
                    "Small",
                    "Medium",
                    "Large"
                },

                Description = "This trouser perfectly pairs with a green shirt."
            },

            new Product
            {
                Title = "A Green Trouser",

                Price = 11,

                Sizes = new string[]
                {
                    "Small"
                },

                Description = "This trouser perfectly pairs with a blue shirt."
            },

            new Product
            {
                Title = "A Blue Trouser",

                Price = 12,

                Sizes = new string[]
                {
                    "Medium"
                },

                Description = "This trouser perfectly pairs with a red shirt."
            },


        };
    }
    [Test]
    public void ExtensionMethods_MostCommonWords_Returns_List_Of_Most_Common_Words_In_Given_List_of_Words()
    {
        var words = new List<string>
        {
            "trouser",
            "trouser",
            "trouser",
            "dance",
            "trouser",
            "blouse",
            "trouser",
            "maim",
            "shirts",
            "trouser",
        };
        var result = words.MostCommonWords();


        StringAssert.AreEqualIgnoringCase("trouser", result.First());
    }


    [TestCase(5)]
    public void ExtensionMethods_MostCommonWordsExcept_Returns_List_Of_Most_Common_Words_except_the_specified_input(
        int take)
    {
        var words = new List<string>
        {
            "trouser",
            "trouser",
            "trouser",
            "dance",
            "trouser",
            "blouse",
            "trouser",
            "maim",
            "shirts",
            "trouser",
        };
        var actualResult = words.MostCommonWordsExcept(take);


        Assert.AreEqual(5, actualResult.Length);
    }

    [Test]
    public void ExtensionMethods_WordsInProductDescription_Returns_List_Of_specified_In_Product_Description()
    {
       

        var actual = _products.WordsInProductDescription();
        Assert.Multiple(() =>
        {
            Assert.IsAssignableFrom<string[]>(actual);
            Assert.AreEqual(24, actual.Length);
        });
    }
    
    
    [Test]
    public void ExtensionMethods_GetAllProductSizes_Returns_List_Of_specified_In_Product_Sizes()
    {
       

        var actual = _products.GetAllProductSizes();
        Assert.Multiple(() =>
        {
            Assert.IsAssignableFrom<string[]>(actual);
            Assert.AreEqual(3, actual.Length);
        });
    }
}