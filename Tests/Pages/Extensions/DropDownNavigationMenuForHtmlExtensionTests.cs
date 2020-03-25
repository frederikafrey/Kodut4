using System.Collections.Generic;
using Abc.Aids;
using Abc.Facade.Quantity;
using Abc.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Extensions
{

    [TestClass]
    public class DropDownNavigationMenuForHtmlExtensionTests : BaseTests
    {

        private string name;
        private Link[] items;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DropDownNavigationMenuForHtmlExtension);
            name = GetRandom.String();
            items = new[] {
                new Link("A", "A.A"),
                new Link("B", "B.B")
            };
        }

        [TestMethod]
        public void DropDownNavigationMenuForTest()
        {
            var obj = new htmlHelperMock<UnitView>().DropDownNavigationMenuFor(name, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> {"<li class=\"nav-item dropdown\">",
                "<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">",
                name,
                "</a>",
                "<div class=\"dropdown-menu\">",
                "<a class='dropdown-item text-dark' href=\"A.A\">A</a>",
                "<a class='dropdown-item text-dark' href=\"B.B\">B</a>",
                "</div>",
                "</li>"
            };
            var actual = DropDownNavigationMenuForHtmlExtension.htmlStrings(name, items);
            TestHtml.Strings(actual, expected);
        }

    }

}