using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FlowHelpers.Models.Array
{
	public class SortArray
	{
		public string Base64EncodedArray { get; set; }
		public bool Descending { get; set; }
		public string OrderByAttribute { get; set; }

		public static string ProcessRequest(SortArray req)
		{
			var descending = req.Descending;
			var attribute = req.OrderByAttribute;
			var strBase64 = req.Base64EncodedArray;
			var base64EncodedBytes = (Convert.FromBase64String(strBase64));
			var str = Encoding.UTF8.GetString(base64EncodedBytes);
			JArray values = JArray.Parse(str);

			JArray sorted = new JArray();
			if (descending == true)
			{
				sorted = new JArray(values.OrderByDescending(obj => (string)obj[attribute]));
			}
			else
			{
				sorted = new JArray(values.OrderBy(obj => (string)obj[attribute]));
			}

			string response = Convert.ToBase64String(Encoding.UTF8.GetBytes(sorted.ToString()));
			return response;
			//Console.WriteLine(sorted.ToString(Formatting.Indented));
		}
	}
}