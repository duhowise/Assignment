using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Assignment.Extensions;
using Assignment.Models;
using NUnit.Framework;

namespace Assignment.Test.Extensions;
[TestFixture]
public class ExtensionMethodsTests
{
    [Test]
    public void ExtensionMethods_MostCommonWords_Returns_List_Of_Most_Common_Words_In_Given_Lisyt_of_Words()
    {
        var words = new List<string>
        {
            "This trouser perfectly diem with a blue dress.",
            "This trouser good pairs with a green ok.",
            "This trouser nice pairs with a red shirt.",

        };
        var result = words.MostCommonWords();



    }
}