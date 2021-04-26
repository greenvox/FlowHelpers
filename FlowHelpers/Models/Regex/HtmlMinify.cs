using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUglify;

namespace FlowHelpers.Models
{
    public class HtmlMinify
    {
        public string html { get; set; }
        public static string ProcessRequest(HtmlMinify req)
        {
            var initialBody = req.html;
            var settings = new NUglify.Html.HtmlSettings
            {
                RemoveOptionalTags = false,
                RemoveEmptyAttributes = false,
                RemoveAttributeQuotes = false,
                DecodeEntityCharacters = true,
                RemoveScriptStyleTypeAttribute = false,
                ShortBooleanAttribute = false,
                MinifyJs = false,
                MinifyJsAttributes = false,
                MinifyCss = false,
                MinifyCssAttributes = false
            };
            var minifiedBody = Uglify.Html(initialBody, settings);

            return minifiedBody.Code;
        }
    }
}