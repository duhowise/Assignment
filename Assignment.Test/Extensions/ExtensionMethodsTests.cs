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


        Assert.Multiple(() =>
        {
           StringAssert.AreEqualIgnoringCase("trouser",result.First());
        });
    }
    
    
    [Test]
    public void ExtensionMethods_MostCommonWordsExcept_Returns_List_Of_Most_Common_Words_except_the_specified_input()
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
        var actualResult =words.MostCommonWordsExcept(5);


        Assert.Multiple(() =>
        {
            Assert.AreEqual(5,actualResult.Length);
        });
    }
}