using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FlowHelpers.Models
{
    public class RegexReplace
    {
        public string StringToSearch { get; set; }
        public string ReplacementValue { get; set; }
        public string RegexPattern { get; set; }

        public static string ProcessRequest (RegexReplace req)
        {
            string stringToSearch = req.StringToSearch;
            string replacementValue = req.ReplacementValue;
            string pattern = req.RegexPattern;

            if (string.IsNullOrEmpty(replacementValue))
                replacementValue = "";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            string replacedString = regex.Replace(stringToSearch, replacementValue);
            return replacedString;
        }

    }
}