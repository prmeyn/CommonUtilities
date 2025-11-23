using Common.Utilities;
using System.Collections.Generic;
using Xunit;

namespace Meyn.Utilities.Tests
{
    public class UtilsTests
    {
        [Fact]
        public void SubstituteTemplate_ReplacesPlaceholders()
        {
            string template = "Hello ##Name##!";
            var args = new Dictionary<string, string>
            {
                { "Name", "World" }
            };
            string result = Utils.SubstituteTemplate(template, args);
            Assert.Equal("Hello World!", result);
        }

        [Fact]
        public void SubstituteTemplate_ReturnsTemplateIfNoPlaceholders()
        {
            string template = "Hello World!";
            var args = new Dictionary<string, string>
            {
                { "Name", "World" }
            };
            string result = Utils.SubstituteTemplate(template, args);
            Assert.Equal("Hello World!", result);
        }

        [Fact]
        public void SubstituteTemplate_ReturnsKeysIfTemplateIsEmpty()
        {
            string template = "";
            var args = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" }
            };
            string result = Utils.SubstituteTemplate(template, args);
            Assert.Contains("Value1", result);
            Assert.Contains("Value2", result);
        }
    }
}
