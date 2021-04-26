using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FlowHelpers.Models
{
    public class RegexExtract
    {
        public string StringToSearch { get; set; }
        public string RegexPattern { get; set; }

        public static string ProcessRequest(RegexExtract req)
        {
            string stringToSearch = req.StringToSearch;
            string extractedString = string.Empty;
            string pattern = req.RegexPattern;

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(stringToSearch);

            if (match.Success)
            {
                extractedString = match.Value;
            }

            return extractedString;
        }
    }
}